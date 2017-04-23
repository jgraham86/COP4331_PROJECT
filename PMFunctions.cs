using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMFunctions: MonoBehaviour {

    private PlayerManager pm;
    public int playerNumber;
    public string loadUsername;
    public int tierNumber;

    private void Awake()
    {
        pm = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    public void assignMatchResults(int winner)
    {

        if (pm.p1 == null || pm.p2 == null)
        {
            Debug.Log("Can't assign match results unless both players loaded");
            return;
        }

        if (winner < 1 || winner > 2)
        {
            Debug.Log("Can't assign match results: winner must be 1 or 2");
            return;
        }

        PlayerManager.Player win = (winner == 1) ? pm.p1 : pm.p2;
        PlayerManager.Player loser = (winner == 1) ? pm.p2 : pm.p1;

        win.gold += 100;
        win.selected.exp += 500;
        win.selected.wins++;

        loser.gold += 25;
        loser.selected.exp += 250;
        loser.selected.losses++;
    }


    public void loadPlayer()
    {
        PlayerManager.Player loadee;

        if (!PlayerPrefs.HasKey(loadUsername))
        {
            Debug.Log("Attempted to load nonexistent player profile. Creating new player.");
            loadee = new PlayerManager.Player(loadUsername);
        }
        else
        {
            loadee = JsonUtility.FromJson<PlayerManager.Player>(PlayerPrefs.GetString(loadUsername));
        }

        loadee.username = loadUsername;

        if (playerNumber == 1)
        {
            pm.p1 = loadee;
        }

        else if (playerNumber == 2)
        {
            pm.p2 = loadee;
        }

        else
        {
            Debug.Log("Attempted to load to player other than 1 or 2");
            return;
        }
    }

    // Includes a write to disk so should be used once upon scene exit.
    // Nothing will occur for null players (e.g. if p2 is not loaded in)
    public void savePlayers()
    {
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

    public void selectChar(int c)
    {
        PlayerManager.Player active = (playerNumber == 1) ? pm.p1 : pm.p2;

        switch (c)
        {
            case 1:
                active.selected = active.char1;
                break;
            case 2:
                active.selected = active.char2;
                break;
            case 3:
                active.selected = active.char3;
                break;
            case 4:
                active.selected = active.char4;
                break;
            default:
                Debug.Log("whachu doin boy");
                break;
        }
    }

    public void setActive()
    {
        pm.active = (playerNumber == 1) ? pm.p1 : pm.p2;
    }

    public void setTier()
    {

        PlayerManager.Char currentChar = pm.active.selected;

        currentChar.tierEquipped = tierNumber;
    }

}
