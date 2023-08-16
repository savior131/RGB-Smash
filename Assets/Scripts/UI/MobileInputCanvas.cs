using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputCanvas : MonoBehaviour
{
    [SerializeField] bool mobileInputActive;

    void setUiMobileInput()
    {
        gameObject.SetActive(mobileInputActive);
    }
}
