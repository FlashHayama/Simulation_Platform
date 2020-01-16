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
        gameObject.transform.Translate(Direction);
    }
    protected void LookHorizon(float horizontal)
    {
        gameObject.transform.Rotate(Vector3.up, horizontal * rotSpeedX);
    }
    protected void LookVertical(float vertical)
    {
        yRot += vertical * rotSpeedY;
        yRot = Mathf.Clamp(yRot, yMinLimit, yMaxLimit);
        myCamera.transform.localEulerAngles = new Vector3(-yRot, 0);
        //Debug.Log(yRot);
    }
}
