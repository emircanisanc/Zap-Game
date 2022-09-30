using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    private int maxPlatform = 50;

    [SerializeField]
    private int directionLimiter = 4;

    [SerializeField]
    private int currentDirection;

    [SerializeField]
    private int maxDiamondCount = 10;

    [SerializeField]
    private int diamondChancePercent = 10;

    [SerializeField]
    private DiamondBehaviour diamondPrefab;

    [SerializeField]
    private Platform platformPrefab;

    [SerializeField]
    private Platform lastPlatform;

    private Queue<DiamondBehaviour> diamonds;

    void Awake()
    {
        diamonds = new Queue<DiamondBehaviour>();
        lastPlatform.setPlatformPool(this);
        DiamondBehaviour lastDiamond;
        for(int index = 1; index < maxDiamondCount; index++)
        {
            lastDiamond = Instantiate(diamondPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            lastDiamond.setPlatformPool(this);
            diamonds.Enqueue(lastDiamond);
        }
        for(int index = 1; index < maxPlatform; index++)
        {
            lastPlatform = Instantiate(platformPrefab, lastPlatform.getPositionAt(nextDirection()), platformPrefab.transform.rotation);
            lastPlatform.setPlatformPool(this);
            if(canSpawnDiamond())
            {
                var diamond = diamonds.Dequeue();
                diamond.moveTo(lastPlatform);
                lastPlatform.setDiamond(diamond);
            }
        }
    }

    int nextDirection()
    {
        if(Mathf.Abs(currentDirection) == directionLimiter)
        {
            if(currentDirection == directionLimiter)
            {
                currentDirection--;
                return 0;
            }
            else
            {
                currentDirection++;
                return 1;
            }
        }
        else
        {
            var newDirection = Random.Range(0, 2);
            if(newDirection == 1)
                currentDirection++;
            else
                currentDirection--;
            return newDirection;
        }
    }

    public void movePlatformToNext(Platform platform)
    {
        platform.transform.position = lastPlatform.getPositionAt(nextDirection());
        lastPlatform = platform;
        if(canSpawnDiamond())
        {
            var diamond = diamonds.Dequeue();
            diamond.moveTo(lastPlatform);
            lastPlatform.setDiamond(diamond);
        }

    }

    private bool canSpawnDiamond()
    {
        if(Random.Range(1, 101) <= diamondChancePercent)
        {
            if(diamonds.Count > 0)
            {
                return true;
            }
        }
        return false;
    }

    public void addDiamondToQueue(DiamondBehaviour newDiamond)
    {
        diamonds.Enqueue(newDiamond);
    }
}
