using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayOneSound))]
public class testCubeEventPlaySong : MonoBehaviour
{

    PlayOneSound playSound;

    public bool activateSound = false;

    private void Start()
    {
        playSound = GetComponent<PlayOneSound>();
    }

    void Update()
    {
        if (activateSound == true)
        {
            playSound.PlaySound();
            activateSound = false;
        }
    }

}
