using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int point;

    private GameObject lastHitObject;

    private PlayerController playerController;
    private BallMovement ballMovement;

    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private UIHandler uIHandler;

    [SerializeField]
    private float killY;

    private float lastY;

    private GameManager gameManager;


    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        ballMovement = GetComponent<BallMovement>();
        gameManager = FindObjectOfType<GameManager>();
        point = 0;
        lastY = transform.position.y;
    }

    void Update()
    {
        if(transform.position.y <= killY && !gameManager.isGameOver())
        {
            playerController.enabled = false;
            cameraController.stopFollowing();
            ballMovement.disableMovement();
            gameManager.endGame(point);
        }
        if(playerController.enabled && playerController.isTouched())
        {
            point++;
            uIHandler.setRecord(point);
        }
    }

}
