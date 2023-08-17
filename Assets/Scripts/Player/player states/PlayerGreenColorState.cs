using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreenColorState : IPlayerStates
{
    public void colorChange(SpriteRenderer newColor)
    {
        newColor.color = new Color(0.31373f, 0.78431f, 0.47059f);
    }
}
