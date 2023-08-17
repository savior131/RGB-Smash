using UnityEngine;

public interface IPlayerStates
{
    void colorChange(SpriteRenderer newColor, Color currentColor, float changeSpeed);
}
