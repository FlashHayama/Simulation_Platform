using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerRay
{
    float mult;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0)
            mult = Time.deltaTime * runSpeed;
        else
            mult = Time.fixedDeltaTime * walkSpeed;

        Move(new Vector3(Input.GetAxis("Horizontal") * mult, 0, Input.GetAxis("Vertical") * mult));
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) Jump();
        LookHorizon(Input.GetAxis("Mouse X") * Time.deltaTime);
        LookVertical(Input.GetAxis("Mouse Y") * Time.deltaTime);
        //Debug.Log(Input.GetAxis("Mouse Y"));
    }
}
