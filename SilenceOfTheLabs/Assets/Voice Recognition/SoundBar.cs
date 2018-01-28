using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBar : MonoBehaviour {

    GameObject bar;

	// Use this for initialization
	void Start () {
        bar = GameObject.Find("Cube");
	}
	
	// Update is called once per frame
	void Update () {
        bar.transform.localScale = new Vector3(1, VoiceRecord.loudness/10, 1);
	}
}
