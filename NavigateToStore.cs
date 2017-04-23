using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateToStore : MonoBehaviour {

    private PlayerManager PM;
    private LevelManager LM;

    public void Awake()
    {
        PM = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void ChooseStore()
    {
       if(PM.active.selected == PM.active.char1)
        {
            LM.LoadLevel("Store Knight");
        }
        if (PM.active.selected == PM.active.char2)
        {
            LM.LoadLevel("Store Orc");
        }
        if (PM.active.selected == PM.active.char3)
        {
            LM.LoadLevel("Store King");
        }
        if (PM.active.selected == PM.active.char4)
        {
            LM.LoadLevel("Store Warboss");
        }
    }
}
