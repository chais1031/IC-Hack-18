using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPermission : MonoBehaviour {

    // Use this for initialization
    IEnumerator Start () {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone)) {

        }
        else {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
