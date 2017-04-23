using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateToPreviousLevel : MonoBehaviour {

	public void storeLevel()
    {
        PlayerPrefs.SetInt("previous", Application.loadedLevel);
    }

    public void goBack()
    {
        int previous = PlayerPrefs.GetInt("previous");
        Application.LoadLevel(previous);
    }
}
