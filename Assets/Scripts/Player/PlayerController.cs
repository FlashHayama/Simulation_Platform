using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerRay
{
    private void FixedUpdate()
    {
        float mult = Time.deltaTime * walkSpeed;
        Move(new Vector3(Input.GetAxis("Horizontal") * mult,0, Input.GetAxis("Vertical") * mult));
    }
}
