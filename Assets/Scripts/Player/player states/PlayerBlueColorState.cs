using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBlueColorState : IPlayerStates
{
    public void colorChange(TrailRenderer newColor)
    {
        //newColor.color = Color.Lerp(currentColor, new(0, 0.27843f, 0.67059f), Time.deltaTime * changeSpeed);
        newColor.startColor = new Color(0, 0.27843f, 0.67059f);
    }
}
