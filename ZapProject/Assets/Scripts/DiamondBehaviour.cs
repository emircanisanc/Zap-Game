using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlatformPool platformPool;

    private MeshRenderer meshRenderer;

    [SerializeField]
    private AudioClip collectedAudioClip;

    private Platform parentPlatform;

    [SerializeField]
    private LayerMask groundLayerMask;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && parentPlatform != null)
        {
            AudioSource.PlayClipAtPoint(collectedAudioClip, transform.position);
            other.GetComponent<PlayerManager>().addDiamond();
            destroyDiamond();
        }
            
    }

    public void destroyDiamond()
    {
        
        if(parentPlatform != null)
        {
            transform.parent = null;
            meshRenderer.enabled = false;
            parentPlatform.setDiamond(null);
            parentPlatform = null;
            platformPool.addDiamondToQueue(this);
        }
        
    }

    public void setPlatformPool(PlatformPool platformPool)
    {
        this.platformPool = platformPool;
    }

    public void moveTo(Platform platform)
    {
        parentPlatform = platform;
        meshRenderer.enabled = true;
        transform.position = platform.getDiamondSocket();
        transform.parent = platform.transform;
    }
}
