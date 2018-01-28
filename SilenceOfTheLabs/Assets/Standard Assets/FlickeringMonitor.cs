using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringMonitor : MonoBehaviour {
	public Material[] materials;
	public int currentMaterial;

	void OnTriggerEnter(Collider other)
	{
		InvokeRepeating ("ChangeScreen", 0.0f, 0.5f);
		GameObject.FindWithTag ("GameController").GetComponent("FlickeringMonitor").BroadcastMessage("OnTriggerEnter");
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeScreen() {
		currentMaterial++;
		currentMaterial %= materials.Length;
		GetComponent<Renderer>().material = materials [currentMaterial];
	}
}
