using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    [HideInInspector] public IPlayerStates currentPlayerTrailColor;
    IPlayerStates[] playerColorTrailStates = {new PlayerRedColorState() 
            , new PlayerGreenColorState() , new PlayerBlueColorState()};
    TrailRenderer TrailColor;
    private void Start()
    {
        TrailColor = GetComponent<TrailRenderer>();
        setTrailColor(playerColorTrailStates[0]);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            setTrailColor(playerColorTrailStates[0]);
            currentPlayerTrailColor.colorChange(TrailColor);
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            setTrailColor(playerColorTrailStates[1]);
            currentPlayerTrailColor.colorChange(TrailColor);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            setTrailColor(playerColorTrailStates[2]);
            currentPlayerTrailColor.colorChange(TrailColor);
        }
        
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
}
