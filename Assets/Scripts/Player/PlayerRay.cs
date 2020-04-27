using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    [SerializeField] private bool canJump = false;
    [SerializeField] private bool canCatch = false;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canForward = false;

    [SerializeField]
    Transform step;
    [SerializeField]
    Transform head;
    [SerializeField]
    Transform torso;

    Ray ray;
    RaycastHit hit;

    private GameObject cont;

    public bool CanJump { get => canJump; }
    public bool CanCatch { get => canCatch; }
    public bool CanMove { get => canMove; }
    public bool CanForward { get => canForward; }

    private void Start()
    {
        cont = GetComponent<PlayerController>().cont;
    }
    private void Update()
    {
        float distance;
        canJump = DefaultRay(step, Vector3.down, gameObject, out distance) && distance < 0.05;

        canForward = (!(DefaultRay(torso, Vector3.forward, gameObject, out distance) && distance < 0.5) && 
            !(DefaultRay(head, Vector3.forward, gameObject, out distance) && distance < 0.5)) || 
            !(hit.collider.tag != "GravityChange");

        canCatch = (DefaultRay(torso, Vector3.forward, gameObject, out distance) && hit.distance < 0.5) && !DefaultRay(head, Vector3.forward, gameObject, out distance) && !canJump;

        if (cont.GetComponent<Rigidbody>().velocity.y < -5 && canCatch)
            cont.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);

        //if (!canJump && GetComponent<PlayerMove>().velocity) canMove = false; else canMove = true;
    }

    private bool DefaultRay(Transform target, Vector3 dir,GameObject obj,out float distance)
    {
        ray = new Ray(target.position, obj.transform.TransformDirection(dir));
        Debug.DrawRay(target.position, obj.transform.TransformDirection(dir), Color.red);
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
