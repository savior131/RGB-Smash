using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    IPlayerStates currentPlayerColor;
    IPlayerStates[] playerColorStates = {new PlayerRedColorState() 
            , new PlayerGreenColorState() , new PlayerBlueColorState()};
    IInputPlayer inputPlayer;
    [SerializeField] SpriteRenderer circleSprite;
    [SerializeField] float changeSpeed=2;
    [SerializeField] bool mobileUiActive;

    bool canChange = true;
    int colorIndex = 0;
    private void Start()
    {
        currentPlayerColor = playerColorStates[Random.Range(0 , playerColorStates.Length)];
        setInputSourse();
    }
    private void Update()
    {
        if (inputPlayer.getColorChangeInput() && canChange)
        {
            colorIndex++;
            colorIndex = colorIndex % playerColorStates.Length;
            currentPlayerColor = playerColorStates[colorIndex];
            canChange = false;
        }
        else if (!inputPlayer.getColorChangeInput())
        {
            canChange = true;
        }
        currentPlayerColor.colorChange(circleSprite,circleSprite.color,changeSpeed);
    }

    private void setInputSourse()
    {
        if (mobileUiActive)
            inputPlayer = GetComponent<MobileController>();
        else
            inputPlayer = GetComponent<ActionsControl>();
    }

}
