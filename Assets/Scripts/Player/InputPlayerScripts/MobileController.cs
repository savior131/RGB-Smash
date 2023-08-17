using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MobileController : MonoBehaviour , IInputPlayer
{
    [SerializeField] VariableJoystick variableJoystick;
    Vector3 playerDir;
    bool inputDash;
    bool inputColorChnage;
    public bool getDashInput()
    {
        return inputDash;
    }

    public Vector3 getMovmentAxis()
    {
        playerDir = new Vector3(variableJoystick.Horizontal , variableJoystick.Vertical , 0);

        return playerDir;
    }
    public bool getColorChangeInput()
    {
        return inputColorChnage;
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
