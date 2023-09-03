using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class IInputPlayer : MonoBehaviour
{
    protected bool inputDash;
    protected bool inputColorChnage;
    protected Vector3 playerDir;
    public abstract Vector3 getMovmentAxis();
    public bool getColorChangeInput()
    {
        return inputColorChnage;
    }
    public bool getDashInput()
    {
        return inputDash;
    }

    void OnDash(InputValue value)
    {
        inputDash = value.isPressed;
    }
    void OnColorChange(InputValue value)
    {
        inputColorChnage = value.isPressed;
    }
    



}
