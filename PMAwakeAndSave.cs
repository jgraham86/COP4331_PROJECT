using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMAwakeAndSave : MonoBehaviour

{
    public int winner;
    
    
    // Use this for initialization
    private void Awake()
    {
        PlayerManager pm = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();

        if (winner == 1)
        {
            pm.p1.gold += 250;
            pm.p2.gold += 100;
        }
        else
        {
            pm.p1.gold += 100;
            pm.p2.gold += 250;
        }


        if (pm.p1 != null)
        {
            PlayerPrefs.SetString(pm.p1.username, JsonUtility.ToJson(pm.p1));
        }

        if (pm.p2 != null)

        {
            PlayerPrefs.SetString(pm.p2.username, JsonUtility.ToJson(pm.p2));
        }

        PlayerPrefs.Save(); // Write to disk
    }

}
	


