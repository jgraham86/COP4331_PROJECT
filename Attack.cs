using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public AudioClip spawnSound;
    public AudioClip hitSound;
    public GameObject hitEffect;

    public CombatController target;

    public float damage;
    public float cost;
    public float delay;

    private float meleeCountdown;

    // For ranged attacks
    public bool isRanged;
    public float baseSpeed;
    [HideInInspector]
    public float speedBoost;   

    void Start ()
    {
        AudioSource.PlayClipAtPoint(spawnSound, transform.position);

        if (!isRanged)
            meleeCountdown = .2f;

        if (isRanged)
        {
            int dir = (target.transform.position.x < transform.position.x) ? -1 : 1;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(dir * baseSpeed * (1 + speedBoost), 0, 0);
        }
    }

    // Damage player if hit
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (target.gameObject.GetInstanceID() == collider.gameObject.GetInstanceID())
        {
            target.Damage(damage, isRanged);

            // If we want to use these 2 commented lines, we'll have to set hitSound
            // and hitEffect to something, otherwise they'll throw an error and
            // Destroy will not be called on this Attack.
            // Play hit FX
            //AudioSource.PlayClipAtPoint(hitSound, transform.position);
            //GameObject hit = Instantiate(hitEffect, transform);

            // Destroys attack after hit
            Destroy(gameObject);
            

        }
    }


    void Update ()
    {
        if (!isRanged)
        {
            meleeCountdown -= Time.deltaTime;

            if (meleeCountdown <= 0)
            {
                damage = 0; // because Destroy(gameObject) isn't working
                DestroyImmediate(gameObject);
            }
        }

        
	}
}
