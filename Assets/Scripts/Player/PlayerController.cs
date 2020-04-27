using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool is_run = false;
    [SerializeField] private bool lock_running = true;

    public GameObject cont;
    float mult;

    private PlayerJump jump;
    private PlayerRay ray;
    
    public bool Is_run { get => is_run; }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        jump = GetComponent<PlayerJump>();
        ray = GetComponent<PlayerRay>();
    }
    private void FixedUpdate()
    {
        if(ray.CanMove)
        {
            GetComponent<PlayerMove>().Move(new Vector3(Input.GetAxis("Horizontal") * mult, 0, Input.GetAxis("Vertical") * mult));
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump.Jump(jump.JumpForce, ray.CanJump,Vector3.up);
            jump.Jump(jump.CatchForce, ray.CanCatch,Vector3.up);
        }
        GetComponent<PlayerMove>().LookHorizon(Input.GetAxis("Mouse X") * Time.deltaTime);
        GetComponent<PlayerMove>().LookVertical(Input.GetAxis("Mouse Y") * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift) && lock_running)
        {
            is_run = !is_run;
        }
        else if(Input.GetKey(KeyCode.LeftShift) && !lock_running)
        {
            is_run = true;
        }
        else if(!lock_running)
        {
            is_run = false;
        }
        if (Input.GetAxis("Vertical") == 0) 
        { 
            is_run = false; 
        }
        
        if (is_run && Input.GetAxis("Vertical") > 0)
        {
            mult = GetComponent<PlayerMove>().RunSpeed;
        }
        else
        {
            mult = GetComponent<PlayerMove>().WalkSpeed;
        }
    }
    
}
