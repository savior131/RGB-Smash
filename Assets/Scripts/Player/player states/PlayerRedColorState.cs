using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerRedColorState : IPlayerStates
{

    public void colorChange(TrailRenderer newColor, Renderer fog, SpriteRenderer whiteBackground, SpriteGlowEffect glowyBackground, float spreadSpeed, float changeSpeed)
    {

        Color color = Color.Lerp(newColor.startColor, new(1, 0, 0), Time.deltaTime*changeSpeed);
        newColor.startColor = color;
        fog.sharedMaterial.SetColor("_FogColor", color);
        whiteBackground.color = color;
        glowyBackground.GlowColor=color;
        glowyBackground.AlphaThreshold = Mathf.PingPong(Time.time, 1f);
    }

}
