using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cont;
    float mult;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        if(GetComponent<PlayerRay>().canMove)
        {
            GetComponent<PlayerMove>().Move(new Vector3(Input.GetAxis("Horizontal") * mult, 0, Input.GetAxis("Vertical") * mult));
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("jump =" + canJump);
            GetComponent<PlayerJump>().Jump(GetComponent<PlayerJump>().jumpForce, GetComponent<PlayerRay>().canJump);
            GetComponent<PlayerJump>().Jump(GetComponent<PlayerJump>().catchForce, GetComponent<PlayerRay>().canCatch);
        }
        GetComponent<PlayerMove>().LookHorizon(Input.GetAxis("Mouse X") * Time.deltaTime);
        GetComponent<PlayerMove>().LookVertical(Input.GetAxis("Mouse Y") * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0)
        {
            mult = GetComponent<PlayerMove>().runSpeed;
        }
        else
        {
            mult = GetComponent<PlayerMove>().walkSpeed;
        }
    }   
}
