using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MobileController : IInputPlayer
{
    [SerializeField] VariableJoystick variableJoystick;
    public override Vector3 getMovmentAxis()
    {
        playerDir = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0);

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

    public void setDashInput()
    {
        StartCoroutine(pressDashInput());
    }

    public void setColorChangeInput()
    {
        StartCoroutine(pressColorChangeInput());
    }
    IEnumerator pressDashInput()
    {
        inputDash = true;
        yield return new WaitForSeconds(0.1f);
        inputDash = false;
    }

    IEnumerator pressColorChangeInput()
    {
        inputColorChnage = true;
        yield return new WaitForSeconds(0.1f);
        inputColorChnage = false;
    }


}
