using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecord : MonoBehaviour {

    AudioSource audio;
    public float sensitivity = 100;
    public static float loudness = 0;

    // Use this for initialization
    void Start () {
//*
        audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        audio.loop = true;
        while(!(Microphone.GetPosition(null) > 0)) { }
        audio.Play();
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

        loudness = GetAveragedVolume() * sensitivity;
        if (loudness > 35)
        {
            print("Too loud!");
        }
        //PlotWave();
	}

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

}
