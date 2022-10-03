using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{

    Rigidbody rg;

    [SerializeField]
    private float speed;

    private Vector3 movement;

    private bool canMove;

    private Vector3 rotateVelocity;

    void Awake()
    {
        rg = GetComponent<Rigidbody>();
        canMove = true;
        rg.maxDepenetrationVelocity = 1;
    }

    void Start()
    {
        startMovement();
    }

    void Update()
    {

        
        if(canMove)
        {
            var temp = rg.velocity.y;
            if(temp > 0)
            {
                temp = 0;
            }
            rg.angularVelocity = rotateVelocity;
            rg.velocity = new Vector3(movement.x, temp, movement.z);
            speed += Time.deltaTime / 100;
        }
        
    }

    public void startMovement()
    {
        movement = new Vector3(-speed, 0 ,0);
        rotateVelocity = (new Vector3(movement.z, 0, -movement.x) * (2 * Mathf.PI * transform.localScale.magnitude) * 10);
    }

    public void toggleDirection()
    {
        if(movement.x != 0)
        {
            movement = new Vector3(0, 0 ,-speed);
        }else
        {
            movement = new Vector3(-speed, 0 ,0);
        }
        rotateVelocity = (new Vector3(movement.z, 0, -movement.x) * (2 * Mathf.PI * transform.localScale.magnitude) * 10);
    }

    public float getSpeed(){
        return speed;
    }

    public void disableMovement()
    {
        canMove = false;
        rg.velocity = new Vector3(rg.velocity.x, -speed*3/2, rg.velocity.z);
    }    

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ground")
        {
            other.GetComponent<Platform>().fall(speed);
        }
    }


}
