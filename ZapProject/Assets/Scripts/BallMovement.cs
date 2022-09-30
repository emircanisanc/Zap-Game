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
            rg.velocity = new Vector3(movement.x, temp, movement.z);
            speed += 0.0002f;
        }
        
    }

    public void startMovement()
    {
        movement = new Vector3(-speed, 0 ,0);
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
    }

    public void disableMovement()
    {
        canMove = false;
        rg.velocity = new Vector3(rg.velocity.x, -speed*3/2, rg.velocity.z);
    }    

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            other.GetComponent<Platform>().fall(speed);
        }
    }

}
