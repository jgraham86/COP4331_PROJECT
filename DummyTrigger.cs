using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTrigger : MonoBehaviour {

    private float triggerCooldown;
    private GameObject dummy;

	// Use this for initialization
	void Awake ()
    {
        dummy = GameObject.Find("Dummy");
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == dummy.GetComponent<BoxCollider2D>())
        {
            dummy.GetComponent<CombatController>().move *= -1;
            triggerCooldown = .5f;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        triggerCooldown -= Time.deltaTime;
	}
}
