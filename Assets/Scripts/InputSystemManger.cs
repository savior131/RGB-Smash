using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemManger : MonoBehaviour
{
    enum controls
    {
        mobile,
        pcAndGamepad,
    }
    [SerializeField] controls control;
    IInputPlayer inputPlayer;

    private void Start()
    {
        setInputSourse();
    }
    void setInputSourse()
    {
        if (control == controls.mobile)
            inputPlayer = GetComponent<MobileController>();
        else
            inputPlayer = GetComponent<ActionsControl>();
    }
    public bool getinputPlayerChangeColor()
    {
        return inputPlayer.getColorChangeInput();
    }
    public bool getinputPlayerDash()
    {
        return inputPlayer.getDashInput();
    }
    public Vector3 getInputPlayerAxisMovment()
    {
        return inputPlayer.getMovmentAxis();
    }
}
