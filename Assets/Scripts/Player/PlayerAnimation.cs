using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] PlayerMovment movement;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Animator animator;
    void Update()
    {
        animator.SetFloat("Velocity",playerRB.velocity.magnitude);
        animator.SetBool("Dash", movement.isDash);

    }

}
