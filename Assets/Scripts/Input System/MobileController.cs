using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : IInputPlayer
{
    [SerializeField] VariableJoystick variableJoystick;
    public override Vector3 getMovmentAxis()
    {
        playerDir = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0);

        return playerDir;
    }
    
}
