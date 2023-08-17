using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRedColorState : IPlayerStates
{
    public void colorChange(SpriteRenderer newColor, Color currentColor,float changeSpeed)
    {
        newColor.color = Color.Lerp(currentColor, new(1f, 0.18039f, 0.18039f), Time.deltaTime*changeSpeed);
    }
}
