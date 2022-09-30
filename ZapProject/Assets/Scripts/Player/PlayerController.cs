using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private BallMovement playerBall;

    void Update()
    {
        if(isTouched())
        {
            if(playerBall)
            {
                if(playerBall.enabled)
                playerBall.toggleDirection();
                else
                FindObjectOfType<GameManager>().startGame();
            }
        }
    }

    public bool isTouched()
    {
        return Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
    }
}
