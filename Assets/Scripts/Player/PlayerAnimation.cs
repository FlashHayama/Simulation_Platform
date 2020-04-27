using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private bool animationForward;

    public Animator animator;
   
    void Update()
    {
        WalkAnimation();
    }
    private void WalkAnimation()
    {
        animationForward = GetComponent<PlayerRay>().CanJump && GetComponent<PlayerRay>().CanForward;
        Debug.Log((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0));
        if (GetComponent<PlayerController>().Is_run && Input.GetAxis("Vertical") > 0 && animationForward)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
        }
        else if((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && animationForward)
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
