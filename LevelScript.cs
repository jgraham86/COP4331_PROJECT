using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    private AudioSource MP;

    void Awake()
    {
        MP = GameObject.Find("Music Player").GetComponent<AudioSource>();        
    }

    public void PlayIt()
    {
        MP.Play();
    }

    public void PauseIt()
    {
        MP.Pause();
    }
	
}
