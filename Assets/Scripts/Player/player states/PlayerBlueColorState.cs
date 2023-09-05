using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBlueColorState : IPlayerStates
{
    Color color;
    public void colorChange(TrailRenderer newColor)
    {
        color = Color.Lerp(newColor.startColor , Color.blue, Time.deltaTime * 2);
        newColor.startColor = color;
    }
}
