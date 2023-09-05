using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionsControl : IInputPlayer
{
    public override Vector3 getMovmentAxis()
    {
        return playerDir;
    }
    public override bool getColorChangeInput()
    {
        return inputColorChnage;
    }
    public override bool getDashInput()
    {
        return inputDash;
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
