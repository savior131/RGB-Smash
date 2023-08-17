using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlueColorState : IPlayerStates
{
    public void colorChange(SpriteRenderer newColor)
    {
        newColor.color = new Color(0, 0.27843f, 0.67059f);
    }
}
