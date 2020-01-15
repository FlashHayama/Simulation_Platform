using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : PlayerMove
{
    protected void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.up) * jumpForce, ForceMode.Impulse);
    }
}
