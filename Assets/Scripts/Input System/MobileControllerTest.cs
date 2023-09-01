using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControllerTest : MonoBehaviour
{
    Touch touch;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("hallow");
                StartCoroutine(doubleTab());
                
            }

        }    
    }

    IEnumerator doubleTab()
    {
        yield return new WaitForSeconds(0.25f);
        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log("player tab");
        }
        else if(touch.phase == TouchPhase.Ended)
        {
            Debug.Log("player tab");
        }
    }
}
