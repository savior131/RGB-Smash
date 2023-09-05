using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;
using UnityEngine.Events;

public class PlayerStateController : MonoBehaviour
{
    [HideInInspector] public IPlayerStates currentPlayerTrailColor;
    IPlayerStates[] playerColorTrailStates = {new PlayerRedColorState() 
            , new PlayerGreenColorState() , new PlayerBlueColorState()};
    [SerializeField] TrailRenderer TrailColor;
    [SerializeField] UnityEvent backgoundChange;
    [SerializeField] UnityEvent colorUpdate;
    bool playerChangeColor;
    bool canChangeColor = true;
    int colorIndex = 0;
    bool canAutoSwitch = false;
    [SerializeField] InputSystemManger playerInput;
    private void Start()
    {
        setTrailColor(playerColorTrailStates[colorIndex]);
    }
    private void Update()
    {
        setPlayerInput();
        playerSwitchColor();
        colorChange();
    }


    void playerSwitchColor()
    {
        if (playerChangeColor && canChangeColor)
        {
            switchColor();
        }
    }

    private void switchColor()
    {
        setColorIndex();
        StartCoroutine(startColorChange(colorIndex));
        StartCoroutine(startColorChange());
        backgoundChange.Invoke();
    }

    private void setColorIndex()
    {
        colorIndex++;
        colorIndex = colorIndex % playerColorTrailStates.Length;
    }

    private void setPlayerInput()
    {
        if(!canAutoSwitch)
        {
            playerChangeColor = playerInput.getinputPlayerChangeColor();
        }
    }

    public void setTrailColor(IPlayerStates newTrailColor)
    {
        currentPlayerTrailColor = newTrailColor;
    }

    public Color getPlayerColor()
    {
        if (currentPlayerTrailColor is PlayerBlueColorState)
            return Color.blue;
        else if (currentPlayerTrailColor is PlayerRedColorState)
            return Color.red;
        else if (currentPlayerTrailColor is PlayerGreenColorState)
            return  Color.green;
        return Color.white;
    }

    void colorChange()
    {
        currentPlayerTrailColor.colorChange(TrailColor);
        colorUpdate.Invoke();
    }

    IEnumerator startColorChange(int colorIndex)
    {
        yield return new WaitForSeconds(0.5f);
        setTrailColor(playerColorTrailStates[colorIndex]);
    }

    IEnumerator startColorChange()
    {
        canChangeColor = false;
        yield return new WaitForSeconds(1f);
        canChangeColor = true;
    }
    public void AutomaticSwitchColor()
    {
        StartCoroutine(makeAutomaticSwitchColor());
    }
    IEnumerator makeAutomaticSwitchColor()
    {
        canAutoSwitch = true;
        playerChangeColor = true;
        yield return new WaitForSeconds(0.5f);
        playerChangeColor = false;
        canAutoSwitch = false;
    }
}
