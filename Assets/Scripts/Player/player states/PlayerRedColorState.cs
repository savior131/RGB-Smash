using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerRedColorState : IPlayerStates
{

    public void colorChange(TrailRenderer newColor)
    {
        Color color = Color.Lerp(newColor.startColor, Color.red, Time.deltaTime * 2);
        newColor.startColor = color;
    }
}
