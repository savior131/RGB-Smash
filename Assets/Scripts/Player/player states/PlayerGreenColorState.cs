using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreenColorState : IPlayerStates
{
    public void colorChange(SpriteRenderer newColor, Color currentColor, float changeSpeed)
    {
        newColor.color = Color.Lerp(currentColor, new(0.31373f, 0.78431f, 0.47059f), Time.deltaTime* changeSpeed);
    }
}
