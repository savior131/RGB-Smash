using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : IInputPlayer
{
    [SerializeField] VariableJoystick variableJoystick;
    Vector3 touchPosition;
    Touch touch;
    bool firstTap= false;
    bool mobileDashInput;
    bool mobileChangeColorInput;
    private void Update()
    {
        Debug.LogWarning(mobileDashInput);
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(Input.touchCount - 1);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.position.x > 0)
            {
                if (touch.phase == TouchPhase.Began && !firstTap)
                {
                    firstTap = true;
                    touch.phase = TouchPhase.Stationary;
                    StartCoroutine(doubleTab());
                }
                if (touch.phase == TouchPhase.Began && firstTap)
                {
                    firstTap = false;
                    StartCoroutine(playerPressedChangeColor());
                }
            }
        }
    }
    public override Vector3 getMovmentAxis()
    {
        playerDir = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0);

        return playerDir;
    }

    public override bool getDashInput()
    {
        return mobileDashInput;
    }

    public override bool getColorChangeInput()
    {
        return mobileChangeColorInput;
    }

    IEnumerator doubleTab()
    {
        yield return new WaitForSeconds(0.2f);
        if (touch.phase == TouchPhase.Ended&&firstTap)
        {
            StartCoroutine(playerPressedDash());
        }
        firstTap = false;
    }
    IEnumerator playerPressedDash()
    {
        mobileDashInput = true;
        yield return new WaitForSeconds(0.2f);
        mobileDashInput= false;
    }
    IEnumerator playerPressedChangeColor()
    {
        mobileChangeColorInput = true;
        yield return new WaitForSeconds(0.2f);
        mobileChangeColorInput= false;
    }

    
}
