using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStart : MonoBehaviour {

    public InstantiateCharacter icp1;
    public InstantiateCharacter icp2;
    private CombatController pc1;
    private CombatController pc2;

    // left, jump, right, melee, fire
    KeyCode[] p1controls = { KeyCode.A, KeyCode.W, KeyCode.D, KeyCode.LeftShift, KeyCode.LeftAlt };
    KeyCode[] p2controls = { KeyCode.Keypad4, KeyCode.Keypad8, KeyCode.Keypad6, KeyCode.Keypad0, KeyCode.KeypadEnter };

    // Use this for initialization
    void Awake ()
    {        
        // Instantiate playerChar prefabs
        pc1 = icp1.go();
        pc2 = icp2.go();

        // Set opponents to each other
        pc1.opponent = pc2;
        pc2.opponent = pc1;

        pc1.healthSlider = GameObject.Find("P1 Health Slider").GetComponent<Slider>();
        pc2.healthSlider = GameObject.Find("P2 Health Slider").GetComponent<Slider>();


        pc1.winScreen = "WinP1";
        pc2.winScreen = "WinP2";

        // Set controls 
        setupControls(pc1, 1);
        setupControls(pc2, 2);


        // Health and maxHealth should be set in the prefab
    }

    private void setupControls(CombatController pc, int playerNumber)
    {
        KeyCode[] controls = (playerNumber == 1) ? p1controls : p2controls;

        pc.leftKey = controls[0];
        pc.jumpKey = controls[1];
        pc.rightKey = controls[2];
        pc.meleeKey = controls[3];
        pc.fireKey = controls[4];
    }
}
    