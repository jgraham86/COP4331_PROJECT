using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeCombatStart : MonoBehaviour {


    public InstantiateCharacter icp1;
    private CombatController pc1;
    private CombatController dummy;

    // left, jump, right, melee, fire
    KeyCode[] p1controls = { KeyCode.A, KeyCode.W, KeyCode.D, KeyCode.LeftShift, KeyCode.LeftAlt };

    // Use this for initialization
    void Awake()
    {
        // Instantiate playerChar prefabs
        pc1 = icp1.go();
        dummy = GameObject.Find("Dummy").GetComponent<CombatController>();   

        // Set opponents to each other
        pc1.opponent = dummy;
        dummy.opponent = pc1;

        // Make player invincible
        pc1.maxHealth = 9999999999999999999;
        pc1.health = 9999999999999999999;

        // Set controls 
        setupControls(pc1, 1);

    }

    private void setupControls(CombatController pc, int playerNumber)
    {
        KeyCode[] controls = p1controls;

        pc.leftKey = controls[0];
        pc.jumpKey = controls[1];
        pc.rightKey = controls[2];
        pc.meleeKey = controls[3];
        pc.fireKey = controls[4];
    }
}
