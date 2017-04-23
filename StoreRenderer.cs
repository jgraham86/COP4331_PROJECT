using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreRenderer : MonoBehaviour
{

    void Start ()
    {
        gameObject.GetComponent < Renderer >().enabled = false;
    }

    public void Show ()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
	}

    public void Hide ()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

}
