using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecord : MonoBehaviour {

    AudioSource aud;
    public static float[] waveData = new float[16];
    public float sensitivity = 100;
    public static float loudness = 0;

    // Use this for initialization
    void Start () {
//*
        aud = GetComponent<AudioSource>();
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

        loudness = GetAveragedVolume() * sensitivity;
        if (loudness > 35)
        {
            print("Too loud!");
        }
        //PlotWave();
	}

    void PlotWave()
    {
        aud.GetSpectrumData(waveData, 0, FFTWindow.Blackman);
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
        aud.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

}
