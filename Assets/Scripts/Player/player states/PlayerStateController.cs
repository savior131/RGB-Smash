using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;

public class PlayerStateController : MonoBehaviour
{
    [HideInInspector] public IPlayerStates currentPlayerTrailColor;
    IPlayerStates[] playerColorTrailStates = {new PlayerRedColorState() 
            , new PlayerGreenColorState() , new PlayerBlueColorState()};
    [SerializeField] float changeSpeed;
    [SerializeField] float spreadSpeed;
    TrailRenderer TrailColor;
    SpriteRenderer whiteBackground;
    SpriteGlowEffect glowyBackground;
    Renderer fog;

    public string redC = "red";
    private void Start()
    {
        whiteBackground = GameObject.FindGameObjectWithTag("White Background").GetComponent<SpriteRenderer>();
        glowyBackground = GameObject.FindGameObjectWithTag("Glowy Background").GetComponent<SpriteGlowEffect>();
        fog = GameObject.FindGameObjectWithTag("Fog").GetComponent<Renderer>();
        TrailColor = GameObject.FindGameObjectWithTag("Trail").GetComponent<TrailRenderer>();
        setTrailColor(playerColorTrailStates[0]);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            setTrailColor(playerColorTrailStates[0]);
            
            
            
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            
            setTrailColor(playerColorTrailStates[1]);

           
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            
            setTrailColor(playerColorTrailStates[2]);
            

        }
        currentPlayerTrailColor.colorChange(TrailColor, fog, whiteBackground, glowyBackground, spreadSpeed, changeSpeed);
        
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
