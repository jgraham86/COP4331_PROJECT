using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

	PlayerManager pm;

	void Awake () {
        pm = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        updateGoldText();
    }

	public void updateGoldText () {
        GetComponent<Text>().text = pm.active.gold.ToString();
    }
}
