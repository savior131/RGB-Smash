using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBlueColorState : IPlayerStates
{

    public void colorChange(TrailRenderer newColor)
    {
        Color color = new Color(0, 0, 1);
        newColor.startColor = color;
    }
}
