﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecord : MonoBehaviour {

	// Use this for initialization
	void Start () {
//*
        AudioSource aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        aud.loop = true;
        while(!(Microphone.GetPosition(null) > 0)) { }
        aud.Play();
/*/

        var audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        audio.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
            audio.Play();
//*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
