using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    private bool canForward;
    void Update()
    {
        WalkAnimation();
    }
    private void WalkAnimation()
    {
        canForward = GetComponent<PlayerRay>().canJump && GetComponent<PlayerRay>().canForward;
        //Debug.Log(canJump);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0 && canForward)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
        }
        else if((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && canForward)
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
