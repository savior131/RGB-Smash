using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRedColorState : IPlayerStates
{
    public void colorChange(SpriteRenderer newColor)
    {
        newColor.color= new Color(1f, 0.18039f, 0.18039f);
    }
}
