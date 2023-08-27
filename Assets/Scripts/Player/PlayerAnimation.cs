using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerMovment movement;
    Rigidbody2D playerRB;
    Animator animator;
    void Start()
    {
        movement = GetComponent<PlayerMovment>();
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        animator.SetFloat("Velocity",playerRB.velocity.magnitude);
        animator.SetBool("Dash", movement.isDash);

    }

}
