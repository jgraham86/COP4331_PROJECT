using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock1 : MonoBehaviour {

    private PlayerManager PM;
    private Button tier1;	

    public void Awake()
    {
        PM = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        tier1 = GameObject.Find("Tier1").GetComponent<Button>();
    }

    void Start()
    {
        if(PM.active.selected.tierUnlocked >= 1)
        {
            Destroy(gameObject);
            if (PM.active.selected == PM.active.char1)
                tier1.GetComponent<Text>().text = "Spartan";
            if (PM.active.selected == PM.active.char2)
                tier1.GetComponent<Text>().text = "Brute";
            if (PM.active.selected == PM.active.char3)
                tier1.GetComponent<Text>().text = "Berserker";
            if (PM.active.selected == PM.active.char4)
                tier1.GetComponent<Text>().text = "Savage";
        }
    }

    //change to var active
    public void Unlock ()
    {
        if (PM.active.gold >= 500)
        {
            PM.active.gold -= 500;
            PM.active.selected.tierUnlocked = 1;
            Destroy(gameObject);
            if (PM.active.selected == PM.active.char1)
                tier1.GetComponent<Text>().text = "Spartan";
            if (PM.active.selected == PM.active.char2)
                tier1.GetComponent<Text>().text = "Brute";
            if (PM.active.selected == PM.active.char3)
                tier1.GetComponent<Text>().text = "Berserker";
            if (PM.active.selected == PM.active.char4)
                tier1.GetComponent<Text>().text = "Savage";

        }
	}
}
