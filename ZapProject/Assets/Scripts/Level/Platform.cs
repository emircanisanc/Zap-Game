using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform diamondSocket;

    [SerializeField]
    private Transform rightTransform;

    [SerializeField]
    private Transform leftTransform;

    [SerializeField]
    private Rigidbody rg;

    private DiamondBehaviour diamond;

    private PlatformPool platformPool;

    [SerializeField]
    private float delayBeforeTeleportMultiplier;

    [SerializeField]
    private float delayBeforeFallMultiplier;

    private bool isFalling;

    private int nearPlatformCount;

    public Vector3 getPositionAt(int right)
    {
        if(right == 1)
        {
            return rightTransform.position;
        }
        else
        {
            return leftTransform.position;
        }
    }

    public Vector3 getDiamondSocket()
    {
        return diamondSocket.position;
    }

    public void setDiamond(DiamondBehaviour diamond)
    {
        this.diamond = diamond;
    }

    public void setPlatformPool(PlatformPool platformPool)
    {
        this.platformPool = platformPool;
    }


    public void fall(float ballSpeed)
    {
        if(!isFalling)
        {
            isFalling = true;
            StartCoroutine(fallAnim(ballSpeed));
        }
        
    }

    private IEnumerator fallAnim(float ballSpeed)
    {
        yield return new WaitForSeconds(delayBeforeFallMultiplier / ballSpeed);
        if(diamond)
        {
            diamond.destroyDiamond();
            diamond = null;
        }
        rg.isKinematic = false;
        rg.useGravity = true;
        yield return new WaitForSeconds(delayBeforeTeleportMultiplier / ballSpeed);
        rg.isKinematic = true;
        rg.useGravity = false;
        platformPool.movePlatformToNext(this);
        isFalling = false;
        

    }


}
