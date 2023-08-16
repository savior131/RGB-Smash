using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float speed;
    float initSpeed;
    [SerializeField] float decelaration;
    [SerializeField] float accelration;
    [SerializeField] bool mobileUiActive;

    Rigidbody2D playerRB;
    IInputPlayer inputPlayer;
    Vector3 playerDir;
    bool playerDash;


    private void Start()
    {
        setInputType();
        playerRB = GetComponent<Rigidbody2D>();
        initSpeed = speed;
    }

    private void setInputType()
    {
        if (mobileUiActive)
            inputPlayer = GetComponent<MobileController>();
        else
            inputPlayer = GetComponent<ActionsControl>();
    }

    private void Update()
    {
        playerDir = inputPlayer.getMovmentAxis();
        playerDash = inputPlayer.getDashInput();
        Debug.Log(playerDash);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerRB.AddForce(accelration * playerDir, ForceMode2D.Force);
        playerRB.velocity = Vector3.ClampMagnitude(playerRB.velocity, speed);
        if (getPlayerStop())
            speed = Mathf.Lerp(speed, 0, Time.deltaTime * decelaration);
        else
            speed = initSpeed;
    }

    bool getPlayerStop()
    {
        return (playerDir.magnitude == 0);
    }
}
