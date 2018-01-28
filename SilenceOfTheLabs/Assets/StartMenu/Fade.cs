using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public Image splashImage;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(4.0f);
/*
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                FadeOut();
                yield return new WaitForSeconds(4.0f);
                SceneManager.LoadScene("SilenceOfTheLabs");
            }
        }
      */  
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 3.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
