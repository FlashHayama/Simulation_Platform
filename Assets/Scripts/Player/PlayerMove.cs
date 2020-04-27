using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;

    [SerializeField] private float rotSpeedX = 100f;
    [SerializeField] private float rotSpeedY = 100f;

    [SerializeField] private bool velocity = false;

    public Camera myCamera;

    float yRot = 0.0f;
    float yMinLimit = -70.0f;
    float yMaxLimit = 70.0f;

    private GameObject cont;

    public float WalkSpeed { get => walkSpeed; set => walkSpeed = value; }
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }
    public float RotSpeedX { get => rotSpeedX; set => rotSpeedX = value; }
    public float RotSpeedY { get => rotSpeedY; set => rotSpeedY = value; }
    public bool Velocity { get => velocity; }

    private void Start()
    {
        cont = GetComponent<PlayerController>().cont;
    }
    /// <summary>
    /// Default movement forward, backward, left, right
    /// </summary>
    /// <param name="Direction">X,Y,Z</param>
    public void Move(Vector3 Direction)
    {
        if (!GetComponent<PlayerRay>().CanForward && Input.GetAxis("Vertical") > 0) Direction.z = 0f;
        //if (!velocity)
        //{
            cont.transform.Translate(transform.TransformDirection(Direction) * Time.fixedDeltaTime, Space.World);
        //}
        //else
        //{
            //Direction = transform.TransformDirection(Direction);
            //Direction.y = transform.TransformDirection(cont.GetComponent<Rigidbody>().velocity).y;
            //cont.GetComponent<Rigidbody>().velocity = (Direction * Time.deltaTime );
        //}
    }
    public void LookHorizon(float horizontal)
    {
        gameObject.transform.Rotate(Vector3.up, horizontal * RotSpeedX,Space.Self);
    }
    public void LookVertical(float vertical)
    {
        yRot += vertical * RotSpeedY;
        yRot = Mathf.Clamp(yRot, yMinLimit, yMaxLimit);
        myCamera.transform.localEulerAngles = new Vector3(-yRot, 0);
    }
    /*public IEnumerator ForwardCatch()
    {
        while (!GetComponent<PlayerRay>().canJump)
        {
            cont.transform.Translate(transform.TransformDirection(Vector3.forward * walkSpeed * Time.fixedDeltaTime), Space.World);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }      
    }*/
}
