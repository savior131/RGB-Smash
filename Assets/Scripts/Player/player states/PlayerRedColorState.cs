using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerRedColorState : IPlayerStates
{
    Color color;
    public void colorChange(TrailRenderer newColor)
    {
        color = Color.Lerp(newColor.startColor, Color.red, Time.deltaTime * 2);
        newColor.startColor = color;
    }
}
