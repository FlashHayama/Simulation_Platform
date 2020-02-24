using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : Variables
{
    [SerializeField]
    Transform step;
    [SerializeField]
    Transform head;
    [SerializeField]
    Transform torso;

    Ray ray;
    RaycastHit hit;
    private void Update()
    {
        float distance;
        canJump = DefaultRay(step, Vector3.down, out distance) && distance < 0.1;

        canForward = (!(DefaultRay(torso, Vector3.forward, out distance) && distance < 0.5) && 
            !(DefaultRay(head, Vector3.forward, out distance) && distance < 0.5)) || 
            !(hit.collider.tag != "GravityChange");
        
        canCatch = (DefaultRay(torso, Vector3.forward, out distance) && hit.distance < 0.5) && !DefaultRay(head, Vector3.forward, out distance) && !canJump;

        if (cont.GetComponent<Rigidbody>().velocity.y < -5 && canCatch)
            cont.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
    }

    private bool DefaultRay(Transform target, Vector3 dir,out float distance)
    {
        ray = new Ray(target.position, transform.TransformDirection(dir));
        Debug.DrawRay(target.position, transform.TransformDirection(dir), Color.red);
        if (Physics.Raycast(ray, out hit, 2))
        {
            //GetComponent<PlayerSong>().PlayLand();
            distance = hit.distance;
            return true;
        }
        else
        {
            distance = hit.distance;
            return false;
        }   
    }
}
