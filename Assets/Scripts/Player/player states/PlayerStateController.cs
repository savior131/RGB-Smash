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
    TrailRenderer TrailColor;
    [SerializeField] UnityEvent backgoundChange;
    [SerializeField] UnityEvent colorUpdate;
    bool playerChangeColor;
    bool canChangeColor = true;
    int colorIndex = 0;
    InputSystemManger playerInput;
    private void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("Input System").GetComponent<InputSystemManger>();
        TrailColor = GameObject.FindGameObjectWithTag("Trail").GetComponent<TrailRenderer>();
        setTrailColor(playerColorTrailStates[colorIndex]);
    }
    private void Update()
    {
        setPlayerInput();
        if (playerChangeColor && canChangeColor)
        {
            setColorIndex();
            StartCoroutine(startColorChange(colorIndex));
            StartCoroutine(startColorChange());
            backgoundChange.Invoke();
        }
        colorChange();
    }

    private void setColorIndex()
    {
        colorIndex++;
        colorIndex = colorIndex % playerColorTrailStates.Length;
    }

    private void setPlayerInput()
    {
        playerChangeColor = playerInput.getinputPlayerChangeColor();
    }

    public void setTrailColor(IPlayerStates newTrailColor)
    {
        currentPlayerTrailColor = newTrailColor;
    }

    public string getPlayerColor()
    {
        if (currentPlayerTrailColor is PlayerBlueColorState)
            return "blue";
        else if (currentPlayerTrailColor is PlayerRedColorState)
            return "red";
        else if (currentPlayerTrailColor is PlayerGreenColorState)
            return "green";
        return "null";
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
        yield return new WaitForSeconds(1.5f);
        canChangeColor = true;
    }
}
