using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    private float distance;

    private Vector3 lastPosition;

    private bool follow;

    void Awake()
    {
        follow = true;
        lastPosition = targetTransform.position;
    }

    void Update()
    {
        if(follow)
        {
            distance = Vector3.Distance(lastPosition, targetTransform.position);
            transform.position =  new Vector3(-distance/2, 0, -distance/2) + transform.position;
            lastPosition = targetTransform.position;
        }
            
    }

    public void stopFollowing()
    {
        follow = false;
    }
}
