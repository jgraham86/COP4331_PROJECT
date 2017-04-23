using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{

    #region vars
    // Opponent and player ID info
    public CombatController opponent;
    public string winScreen;

    // practice dummy stuff
    public bool isDummy = false;
    private float dummyMoveCooldown;

    // Controls
    private bool controlsEnabled = true;
    public KeyCode leftKey;
    public KeyCode jumpKey;
    public KeyCode rightKey;
    public KeyCode meleeKey;
    public KeyCode fireKey;

    // Animation
    private Animator animator;
    public int move;
    private bool jump;

    // Movement 
    private Rigidbody2D rb;
    public LayerMask ground;
    private Transform[] groundChecks = new Transform[3];
    //private CapsuleCollider2D groundCheck;
    public bool grounded;
    private float groundCheckRadius = .2f;
    private bool facingRight = true;

    // Movement stats
    public float maxSpeed = 10f;
    public float jumpForce = 500f;

    // Abilities
    public Attack meleeAttack;
    public Attack rangedAttack;

    // Combat stats 
    public float health;
    public float maxHealth = 1000;
    public Slider healthSlider;

    // Timers
    public float attackAnimationDuration = 0.2f;
    public float attackAnimationTimer = 0;
    public float jumpDelay = 0.5f;
    public float jumpCooldown = 0;
    public float rangedDelay = 0.5f;
    public float meleeDelay = 1f;
    private float rangedCooldown = 0;
    private float meleeCooldown = 0;
    private float deathTimer = 3f;
    private bool dying = false;
    
    #endregion vars

    private void Awake()
    {
        //groundCheck = transform.Find("GroundCheck").GetComponent<CapsuleCollider2D>();
        groundChecks[0] = transform.Find("GroundCheck1");
        groundChecks[1] = transform.Find("GroundCheck2");
        groundChecks[2] = transform.Find("GroundCheck3");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (isDummy)
            move = -1;
    }

    private void Update()
    {

        // Set grounded status
        grounded = false;

        foreach (Transform t in groundChecks)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(t.position, groundCheckRadius, ground);
            foreach (Collider2D col in colliders)
            {
                if (col.gameObject.layer == 8)
                {
                    grounded = true;
                }
            }
        }

        // Update cooldowns
        jumpCooldown -= Time.deltaTime;
        rangedCooldown -= Time.deltaTime;
        meleeCooldown -= Time.deltaTime;
        attackAnimationTimer -= Time.deltaTime;

        // Check for death
        if (dying)
            deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
            Die();

        // Face player towards opponent
        FaceOpponent();

        // Respond to player input
        if (!dying && !isDummy)
            PlayerControl();

        if (isDummy)
        {
            if (!dying)
                DummyControl();
            dummyMoveCooldown -= Time.deltaTime;
        }
        
        

        // Move char according to vars set in PlayerControl()
        if (!dying)
            CharacterAction();
    }

    /// TODO: 
    /// - Verify that jump animation will persist after air attack (if appropriate)
    /// - Ensure char resets to idle animation appropriately
    // Moves charater in response to vars set in playerControl()
    void CharacterAction()
    {
        // Handle movement animation and jump
        if (grounded)
        {
            if (move != 0 && attackAnimationTimer <= 0)
                animator.SetInteger("AnimState", 1);
            else if (attackAnimationTimer <= 0)
                animator.SetInteger("AnimState", 0);

            if (jump)
            {
                grounded = false;
                if (attackAnimationTimer <= 0)
                    animator.SetInteger("AnimState", 3);
                rb.velocity = new Vector3(move * maxSpeed, jumpForce);
                //rb.AddForce(new Vector2(0f, jumpForce));
                jumpCooldown = jumpDelay;
            }

            // Attack animation is handled in melee() and fire()
        }
        else if (attackAnimationTimer <= 0)
            animator.SetInteger("AnimState", 3);

        // Move the character
        rb.velocity = new Vector3(move * maxSpeed, rb.velocity.y);
    }

    // Sets vars to control player movement and handles attacks
    void PlayerControl()
    {
        move = 0;
        
        // Player presses fire key
		if (controlsEnabled && Input.GetKeyDown(fireKey) && rangedCooldown <= 0)
			InvokeRepeating ("Fire", 0.0001f, rangedDelay);
        if (Input.GetKeyUp(fireKey))
            CancelInvoke("Fire");

        // Player presses melee key
        if (controlsEnabled && Input.GetKeyDown(meleeKey) && meleeCooldown <= 0)
            Melee();

        // Player presses left key
        if (controlsEnabled && Input.GetKey(leftKey))
            move -= 1;

        // Player presses right key
        if (controlsEnabled && Input.GetKey(rightKey))
            move += 1;

        // Player presses jump key
        jump = (controlsEnabled && Input.GetKey(jumpKey) && jumpCooldown <= 0);
    }

    void DummyControl()
    {
        float chance = Random.value;
        float moveTime = Random.value;
        float baseCooldown = 2f;

        if (dummyMoveCooldown < 0)
        {
            jump = false;

            if (chance < .5f)
                move *= -1;

            else if (chance > .7f)
            {
                // jump real quick
                jump = true;
                
            }

            dummyMoveCooldown = .5f + baseCooldown * moveTime;
        }
    }

    private void FaceOpponent()
    {
        
            if ((opponent.transform.position.x < transform.position.x && facingRight)
                || (opponent.transform.position.x > transform.position.x && !facingRight))
            {
                facingRight = !facingRight;
                Vector3 charScale = transform.localScale;
                charScale.x *= -1;
                transform.localScale = charScale;
            }
    }

    void Fire()
    {
        if (rangedCooldown <= 0)
        {
            // Don't change to attack animation for nonmelee attacks

            int dir = (facingRight) ? 1 : -1;
            GameObject missileObject = Instantiate(rangedAttack.gameObject, transform.position + new Vector3(dir, 0, 0), Quaternion.identity) as GameObject;
            Attack missile = missileObject.GetComponent<Attack>();
            missile.target = opponent;

            rangedCooldown = rangedDelay;
        } 
    }

    void Melee()
    {
        if (meleeCooldown <= 0)
        {
            animator.SetInteger("AnimState", 2);
            attackAnimationTimer = attackAnimationDuration;


            int dir = (facingRight) ? 1 : -1;
            GameObject meleeObject = Instantiate(meleeAttack.gameObject, transform.position + new Vector3(dir, 0, 0), Quaternion.identity) as GameObject;
            Attack melee = meleeObject.GetComponent<Attack>();
            melee.target = opponent;

            meleeCooldown = meleeDelay;
        }
    }
    
    // Attacks should call this 
    public void Damage(float power, bool isRanged)  /// isRanged nolonger used
    {
        health -= power;

        if (health <= 0)
        {
			animator.SetInteger ("AnimState", 5);
            dying = true;
            controlsEnabled = false;
        }

        healthSlider.value = health;
    }

    void Die()
    {
        LevelManager lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        lm.LoadLevel(opponent.winScreen);
    }
}
