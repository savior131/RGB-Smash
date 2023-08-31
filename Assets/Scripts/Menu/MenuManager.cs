using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void onStartPress()
    {
        Camera.main.GetComponent<CameraShake>().Shake(0.3f, 1.8f, 20);
        // AsyncOperation operation= SceneManager.LoadSceneAsync(1);
    }
    public void onAboutPress()
    {
        Camera.main.GetComponent<CameraShake>().Shake(0.3f, 1.8f, 20);
    }
    public void onBackPressed()
    {
        Camera.main.GetComponent<CameraShake>().Shake(0.3f, 1.8f, 20);
    }
    public void onExitPress()
    {
        Application.Quit();
    }
}
