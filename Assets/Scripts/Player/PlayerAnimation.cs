using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Variables
{
    public Animator animator;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0 && canJump)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
        }
        else if((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && canJump)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
        }
    }
}
