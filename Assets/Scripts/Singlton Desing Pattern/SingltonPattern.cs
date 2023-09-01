using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingltonPattern : MonoBehaviour
{
    protected void mangeSelgalton()
    {
        int instant = FindObjectsOfType(GetType()).Length;
        if (instant > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
