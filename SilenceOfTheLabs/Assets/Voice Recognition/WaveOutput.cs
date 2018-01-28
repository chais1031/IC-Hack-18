using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOutput : MonoBehaviour {

    public GameObject cube;
    public GameObject[] cubes = new GameObject[16];
    public float maxScale;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 16; i++)
        {
            GameObject soundCube = (GameObject)Instantiate(cube);
            soundCube.transform.position = this.transform.position;
            soundCube.transform.parent = this.transform;
            soundCube.name = "soundCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            soundCube.transform.position = Vector3.forward * 100;
            cubes[i] = soundCube;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int j = 0; j < 16; j++)
        {
            if (cubes != null)
            {
                cubes[j].transform.localPosition = new Vector3(10, VoiceRecord.waveData[j] * maxScale + 2, 10);
            }
        }
	}
}
