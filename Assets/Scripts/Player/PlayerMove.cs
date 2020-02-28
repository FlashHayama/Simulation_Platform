using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    public float rotSpeedX = 100f;
    public float rotSpeedY = 100f;

    public Camera myCamera;

    float yRot = 0.0f;
    float yMinLimit = -70.0f;
    float yMaxLimit = 70.0f;

    private GameObject cont;
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
        Debug.Log("canforward = " + GetComponent<PlayerRay>().canForward);
        if (!GetComponent<PlayerRay>().canForward && Input.GetAxis("Vertical") > 0) Direction.z = 0f;

        cont.transform.Translate(transform.TransformDirection(Direction) * Time.fixedDeltaTime,Space.World);
    }
    public void LookHorizon(float horizontal)
    {
        gameObject.transform.Rotate(Vector3.up, horizontal * rotSpeedX,Space.Self);
    }
    public void LookVertical(float vertical)
    {
        yRot += vertical * rotSpeedY;
        yRot = Mathf.Clamp(yRot, yMinLimit, yMaxLimit);
        myCamera.transform.localEulerAngles = new Vector3(-yRot, 0);
        //Debug.Log(yRot);
    }
}
