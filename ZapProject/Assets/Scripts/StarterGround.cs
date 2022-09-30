using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterGround : MonoBehaviour
{
    void OnCollisionExit(Collision other)
    {
        StartCoroutine(fallAnim());
    }

    private IEnumerator fallAnim()
    {
        int i = 30;
        while(i > 0)
        {
            i--;
            yield return new WaitForSeconds(0.03f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        }
        
        Destroy(gameObject);

    }
}
