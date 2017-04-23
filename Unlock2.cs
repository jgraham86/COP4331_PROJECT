using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock2 : MonoBehaviour
{

    private PlayerManager PM;
    private Button tier2;

    public void Awake()
    {
        PM = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        tier2 = GameObject.Find("Tier2").GetComponent<Button>();
    }

    void Start()
    {
        if (PM.active.selected.tierUnlocked == 2)
        {
            Destroy(gameObject);
            if(PM.active.selected == PM.active.char1)
                tier2.GetComponent<Text>().text = "Titan";
            if (PM.active.selected == PM.active.char2)
                tier2.GetComponent<Text>().text = "Uruk-hai";
            if (PM.active.selected == PM.active.char3)
                tier2.GetComponent<Text>().text = "Blood Lord";
            if (PM.active.selected == PM.active.char4)
                tier2.GetComponent<Text>().text = "Mauler";
        }
    }

    //change to var active
    public void Unlock()
    {
        if (PM.active.selected.tierUnlocked == 1 && PM.active.gold >= 1000)
        {
            PM.active.gold -= 1000;
            PM.active.selected.tierUnlocked = 2;
            Destroy(gameObject);
            if (PM.active.selected == PM.active.char1)
                tier2.GetComponent<Text>().text = "Titan";
            if (PM.active.selected == PM.active.char2)
                tier2.GetComponent<Text>().text = "Uruk-hai";
            if (PM.active.selected == PM.active.char3)
                tier2.GetComponent<Text>().text = "Blood Lord";
            if (PM.active.selected == PM.active.char4)
                tier2.GetComponent<Text>().text = "Mauler";
        }
    }
}