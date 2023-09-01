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

    void OnMove(InputValue value)
    {
        playerDir = value.Get<Vector2>();
    }
}
