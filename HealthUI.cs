using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    private GameObject healthObject;

    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        healthObject = GameObject.Find("Knight1");
        healthObject.GetComponent<CombatController>().health = healthObject.GetComponent<CombatController>().maxHealth;

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    void Update()
    {

        //        barDisplay = MyControlScript.staticHealth;
        barDisplay = healthObject.GetComponent<CombatController>().health;
    }
}