using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private BallMovement playerBall;

    private bool isStarted;

    [SerializeField]
    private AudioClip onBallMovementClip;

    void Update()
    {
        if(isTouched())
        {
            if(playerBall)
            {
                if(isStarted && playerBall.enabled){
                    toggleBallDirection();
                }else{
                    isStarted = true;
                    FindObjectOfType<GameManager>().startGame();
                }
            }
        }
    }

    private void toggleBallDirection(){
        AudioSource.PlayClipAtPoint(onBallMovementClip, transform.position);
        playerBall.toggleDirection();
    }

    public bool isTouched()
    {   
        if(Input.GetKeyDown(KeyCode.Space)){
            return true;
        }else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            return !(EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId));
        }else{
            return false;
        }
    }
}
