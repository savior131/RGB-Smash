using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerRedColorState : IPlayerStates
{

    public void colorChange(TrailRenderer newColor)
    {
        Color color = new Color(1, 0, 0);
        newColor.startColor = color;
    }
}
