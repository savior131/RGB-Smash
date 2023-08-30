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

    private void Start()
    {
        TrailColor = GetComponent<TrailRenderer>();
        setTrailColor(playerColorTrailStates[0]);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            StartCoroutine(startColorChange(0));
            backgoundChange.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(startColorChange(1));
            backgoundChange.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(startColorChange(2));
            backgoundChange.Invoke();
        }
        colorChangeCoroutine();
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

    void colorChangeCoroutine()
    {
        currentPlayerTrailColor.colorChange(TrailColor);
        colorUpdate.Invoke();
    }

    IEnumerator startColorChange(int colorIndex)
    {
        yield return new WaitForSeconds(0.5f);
        setTrailColor(playerColorTrailStates[colorIndex]);
    }
}
