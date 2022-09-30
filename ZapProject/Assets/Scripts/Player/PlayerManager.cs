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

    [SerializeField]
    private float disableControlY;

    private GameManager gameManager;

    private int diamond;


    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        ballMovement = GetComponent<BallMovement>();
        gameManager = FindObjectOfType<GameManager>();
        point = 0;
    }

    void Update()
    {
        if(playerController.enabled && !gameManager.isGameOver() && transform.position.y <= disableControlY){
            playerController.enabled = false;
        }

        if(transform.position.y <= killY && !gameManager.isGameOver())
        {
            cameraController.stopFollowing();
            ballMovement.disableMovement();
            gameManager.endGame(point);
            PlayerPrefs.SetInt("diamond", diamond + PlayerPrefs.GetInt("diamond", 0));
        }
        if(playerController.enabled && playerController.isTouched())
        {
            point++;
            uIHandler.setRecord(point);
        }
    }

    public void addDiamond(){
        diamond++;
        uIHandler.setDiamond(diamond);
    }

}
