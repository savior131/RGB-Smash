using SpriteGlow;
using System.Collections;
using UnityEngine;

public interface IPlayerStates
{

    void colorChange(TrailRenderer newColor, Renderer fog, SpriteRenderer whiteBackground, SpriteGlowEffect glowyBackground, float changeSpeed);
    void spread(Animator animator);
   
}
