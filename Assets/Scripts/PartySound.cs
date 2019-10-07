using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySound : MonoBehaviour
{
    public AudioSource mySound;

        // Use this for initialization
        void Start()
        {
            var audioClip = Resources.Load<AudioClip>("SoundToPlay");  //Load the AudioClip from the Resources Folder
            mySound.clip = audioClip;  //Assign it as AudioSource's clip
        }

        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
                mySound.Play();
            }
        if (Input.GetKeyUp("p"))
        {
            mySound.Stop();
        }


    }
        
}
