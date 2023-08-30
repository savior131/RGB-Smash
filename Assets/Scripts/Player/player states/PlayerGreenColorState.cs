using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerGreenColorState : IPlayerStates
{

    public void colorChange(TrailRenderer newColor)
    {
        Color color = new Color(0, 1, 0);;
        newColor.startColor = color;
    }
}
