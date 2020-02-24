using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerMove
{
    float mult;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        if(canMove)
        {
            Move(new Vector3(Input.GetAxis("Horizontal") * mult, 0, Input.GetAxis("Vertical") * mult));
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("jump =" + canJump);
            GetComponent<PlayerJump>().Jump(jumpForce,canJump);
            GetComponent<PlayerJump>().Jump(catchForce,canCatch);
        }
        LookHorizon(Input.GetAxis("Mouse X") * Time.deltaTime);
        LookVertical(Input.GetAxis("Mouse Y") * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0)
        {
            mult = runSpeed;
        }
        else
        {
            mult = walkSpeed;
        }
    }
    
}
