using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear : MonoBehaviour {

    private float speed = .2f;
    private Vector2 place;
    private float change;

	void Start ()
    {
        place = transform.position;
	}
	
	void Update ()
    {
        change += speed * Time.deltaTime;
        var offset = new Vector2(1f, 0f) * change;
        transform.position = place + offset;
    }
}
