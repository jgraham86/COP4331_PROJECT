using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager pm;

    public Player active;
    public Player p1;
    public Player p2;

    private void Awake()
    {

        // Prevent duplication

        if (pm!= null)

        {

            Debug.Log("Attempted to duplicate game manager");

            DestroyImmediate(this);

        }

        pm = this;

        DontDestroyOnLoad(this.gameObject);
    }

    [System.Serializable]
    public class Player
    {
        public Player(string username)
        {
            this.username = username;

            char1 = new Char();
            char2 = new Char();
            char3 = new Char();
            char4 = new Char();
            // TODO: Assign default sprite strings to the Chars
        }

        public string username;

        public Char char1;
        public Char char2;
        public Char char3;
        public Char char4;

        public Char selected;

        public int gold;

        public int wins()
        {
            return char1.wins + char2.wins + char3.wins + char4.wins;
        }

        public int losses()
        {
            return char1.losses + char2.losses + char3.losses + char4.losses;
        }
    }

    [System.Serializable]
    public class Char
    {
        public string spriteName;   // should be changed upon selection in store

        // TODO: Insert any other stats that need to be tracked, like movement speed

        public int maxHP;
        public int tierUnlocked;    // tiers of gear unlocked
        public int tierEquipped;
        public int exp;
        public int wins;
        public int losses;

        public int level()
        {
            return exp / 1000 + 1;  // arbitrary
        }
    }
}