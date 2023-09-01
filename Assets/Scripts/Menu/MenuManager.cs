using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public void shake()
    {
        Camera.main.GetComponent<CameraShake>().Shake(0.3f, 1.8f, 20);
    }
    public void onPausePress()
    {
        Time.timeScale = 0f;
    }
    public void onContinuePress()
    {
        Time.timeScale = 1f;
    }
    public void onExitPress()
    {
        Application.Quit();
    }
}
