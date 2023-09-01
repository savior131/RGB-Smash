using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControllerTest : MonoBehaviour
{
    Touch touch;
    bool firstTap= false;
    private void Update()
    {

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began&&!firstTap)
            {
                firstTap = true;
                touch.phase = TouchPhase.Stationary;
                StartCoroutine(doubleTab());
                
            }
            if (touch.phase==TouchPhase.Began&&firstTap)
            {
                firstTap=false;
                Debug.Log("double tap 3");
            }

        }    
    }

    IEnumerator doubleTab()
    {
        yield return new WaitForSeconds(0.2f);
        if(touch.phase == TouchPhase.Ended&&firstTap)
        {
            Debug.Log("Hello");
        }
        firstTap = false;
    }
}
