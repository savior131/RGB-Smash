using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionsControl : MonoBehaviour, IInputPlayer
{
    bool inputDash;
    bool inputColorChnage;
    Vector3 playerDir;
    public bool getDashInput()
    {
        return inputDash;
    }
    public Vector3 getMovmentAxis()
    {
        return playerDir;
    }
    public bool getColorChangeInput()
    {
        return inputColorChnage;
    }
    void OnMove(InputValue value)
    {
        playerDir = value.Get<Vector2>();
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
