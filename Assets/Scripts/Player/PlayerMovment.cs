using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    enum controls
    {
        mobile ,
        pc ,
        gamepad
    }
    #region movment data
    [SerializeField] float speed;
    [SerializeField] float decelaration;
    [SerializeField] float accelration;
    float initSpeed;
    #endregion
    [SerializeField] controls control;
    #region refrance data
    Rigidbody2D playerRB;
    IInputPlayer inputPlayer;
    Vector3 playerDir;
    bool playerDash;
    #endregion
    #region dash data
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;
    [SerializeField] float coolTimeDash;
    bool isDash;
    bool canDash;
    #endregion

    private void Start()
    {
        setInputSourse();
        playerRB = GetComponent<Rigidbody2D>();
        initSpeed = speed;
        canDash = true;
    }
    private void Update()
    {
        if (playerDash && canDash)
        {
            StartCoroutine(startDashCoroutines());
        }
    }
    private void FixedUpdate()
    {
        if (!isDash)
        {
            setPlayerInput();
            MovePlayer();
        }
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

    IEnumerator startDashCoroutines()
    {
        isDash = true;
        canDash = false;
        playerRB.velocity = playerDir * dashSpeed;
        yield return new WaitForSeconds(dashTime);
        isDash = false;
        yield return new WaitForSeconds(coolTimeDash);
        canDash = true;
    }
    bool getPlayerStop()
    {
        return playerDir.magnitude == 0;
    }

    private void setInputSourse()
    {
        if (control == controls.mobile)
            inputPlayer = GetComponent<MobileController>();
        else
            inputPlayer = GetComponent<ActionsControl>();
    }

    private void setPlayerInput()
    {
        playerDir = inputPlayer.getMovmentAxis();
        playerDash = inputPlayer.getDashInput();
    }
}
