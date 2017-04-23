using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstantiateCharacter : MonoBehaviour {
    
    public int PlayerNumber;

    public GameObject char1Tier0;
    public GameObject char1Tier1;
    public GameObject char1Tier2;

    public GameObject char2Tier0;
    public GameObject char2Tier1;
    public GameObject char2Tier2;

    public GameObject char3Tier0;
    public GameObject char3Tier1;
    public GameObject char3Tier2;

    public GameObject char4Tier0;
    public GameObject char4Tier1;
    public GameObject char4Tier2;


    public CombatController go()
    {
        PlayerManager.Player player;
        GameObject pmHolder = GameObject.Find("PlayerManager");

        if (pmHolder != null)
        {
            player = (PlayerNumber == 1) ? pmHolder.GetComponent<PlayerManager>().p1 :
                pmHolder.GetComponent<PlayerManager>().p2;
        }
        else
            player = null;

        GameObject pc = Instantiate(prefab(player), transform.position, transform.rotation);
        pc.name = "Player " + PlayerNumber;
        return pc.GetComponent<CombatController>();
    }

    private GameObject prefab(PlayerManager.Player player)
    {
        if (player == null)    
        {
            Debug.Log("Player not found... defaulting to char 1 or 2");
            return (PlayerNumber == 1) ? char1Tier0 : char2Tier0;
        }

        if (player.selected == player.char1)            
            return prefabForTier(player.char1.tierEquipped, 1);

        if (player.selected == player.char2)
            return prefabForTier(player.char2.tierEquipped, 2);

        if (player.selected == player.char3)
            return prefabForTier(player.char3.tierEquipped, 3);

        if (player.selected == player.char4)
            return prefabForTier(player.char4.tierEquipped, 4);

        return null;
    }

    // c = char
    private GameObject prefabForTier(int tier, int c)
    {
        switch (c)
        {
            case 1:
                switch (tier)
                {
                    case 0:
                        return char1Tier0;
                    case 1:
                        return char1Tier1;
                    case 2:
                        return char1Tier2;
                    default:
                        return null;
                }
            case 2:
                switch (tier)
                {
                    case 0:
                        return char2Tier0;
                    case 1:
                        return char2Tier1;
                    case 2:
                        return char2Tier2;
                    default:
                        return null;
                }
            case 3:
                switch (tier)
                {
                    case 0:
                        return char3Tier0;
                    case 1:
                        return char3Tier1;
                    case 2:
                        return char3Tier2;
                    default:
                        return null;
                }
            case 4:
                switch (tier)
                {
                    case 0:
                        return char4Tier0;
                    case 1:
                        return char4Tier1;
                    case 2:
                        return char4Tier2;
                    default:
                        return null;
                }
            default:
                return null;
        }


    }
}
