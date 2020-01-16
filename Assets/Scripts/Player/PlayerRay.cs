using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : PlayerMove
{
    [SerializeField]
    Transform step;

    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        ray = new Ray(step.position, transform.TransformDirection(Vector3.down));

        if(Physics.Raycast(ray,out hit,Mathf.Infinity) && hit.distance < 0.1)
        {
            canJump = true;
            //Debug.Log(canJump);
        }
        else
        {
            canJump = false;
        }
        //Debug.DrawRay(step.position, transform.TransformDirection(Vector3.down), Color.red);
        //Debug.Log(hit.distance < 0.1);
        //Debug.Log(Physics.Raycast(ray, out hit, Mathf.Infinity));
    }
    protected void Jump()
    {
        if(canJump)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(
                transform.TransformDirection(Vector3.up) * jumpForce,
                ForceMode.Impulse);
        }
        //Debug.Log("saut" + transform.TransformDirection(Vector3.up) * jumpForce);
        //Debug.Log(gameObject.tag);
        //Debug.Log(canJump);
    }
}
