using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Variables
{
    public Camera myCamera;
    float yRot = 0.0f;
    float yMinLimit = -70.0f;
    float yMaxLimit = 70.0f;
    
    /// <summary>
    /// Default movement forward, backward, left, right
    /// </summary>
    /// <param name="Direction">X,Y,Z</param>
    protected void Move(Vector3 Direction)
    {
        if (!canForward && Input.GetAxis("Vertical") > 0) Direction.z = 0f;
            cont.transform.Translate(transform.TransformDirection(Direction) * Time.fixedDeltaTime,Space.World);
    }
    protected void LookHorizon(float horizontal)
    {
        gameObject.transform.Rotate(Vector3.up, horizontal * rotSpeedX,Space.Self);
    }
    protected void LookVertical(float vertical)
    {
        yRot += vertical * rotSpeedY;
        yRot = Mathf.Clamp(yRot, yMinLimit, yMaxLimit);
        myCamera.transform.localEulerAngles = new Vector3(-yRot, 0);
        //Debug.Log(yRot);
    }
}
