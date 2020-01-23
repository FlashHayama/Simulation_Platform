using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : PlayerMove
{
    [SerializeField]
    Transform step;
    [SerializeField]
    Transform head;
    [SerializeField]
    Transform torso;

    Ray ray,ray2;
    RaycastHit hit;
    private void Update()
    {
        JumpRay();
        ForwardRay();
    }
    protected void Jump()
    {
        if(canJump)
        {
            GetComponent<PlayerSong>().PlayJump();
            cont.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
            cont.GetComponent<Rigidbody>().AddForce(
                transform.TransformDirection(Vector3.up) * jumpForce,
                ForceMode.Impulse);
        }
    }
    protected void TryCatch()
    {
        if(canCatch)
        {
            GetComponent<PlayerSong>().PlayJump();
            cont.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
            cont.GetComponent<Rigidbody>().AddForce(
                transform.TransformDirection(Vector3.up) * catchForce,
                ForceMode.Impulse);
        }
    }
    private void JumpRay()
    {
        ray = new Ray(step.position, transform.TransformDirection(Vector3.down));

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.distance < 0.1)
        {
            //GetComponent<PlayerSong>().PlayLand();
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        Debug.DrawRay(step.position, transform.TransformDirection(Vector3.down), Color.red);
        //Debug.Log("step :" + Physics.Raycast(ray, 2));
        //Debug.Log(hit.distance);
    }
    private void ForwardRay()
    {
        ray = new Ray(head.position, transform.TransformDirection(Vector3.forward));
        ray2 = new Ray(torso.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray2, out hit, 2) && hit.distance < 0.5 && !Physics.Raycast(ray, 2) && !canJump)
        {
            canCatch = true;

            if (cont.GetComponent<Rigidbody>().velocity.y < -5)
                cont.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
        }
        else
        {
            canCatch = false;
        }
        if (((Physics.Raycast(ray2, out hit, 1) && hit.distance < 0.5) || (Physics.Raycast(ray, out hit, 1) && hit.distance < 0.5)) && hit.collider.tag != "GravityChange")
        {
            canForward = false;
        }
        else
        {
            canForward = true;
        }
        //Debug.Log(Physics.Raycast(ray, 2));
        //Debug.Log("head :" + !Physics.Raycast(ray, 2));
        Debug.DrawRay(head.position, transform.TransformDirection(Vector3.forward), Color.red);
        Debug.DrawRay(torso.position, transform.TransformDirection(Vector3.forward), Color.red);
    }
}
