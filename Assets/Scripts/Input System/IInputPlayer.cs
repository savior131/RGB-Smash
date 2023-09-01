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
    public abstract bool getDashInput();

    public abstract bool getColorChangeInput();



}
