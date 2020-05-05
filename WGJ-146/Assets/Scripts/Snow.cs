using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public GameObject snowDestroyVFX;
    public GameObject debris;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == GameTriggers.Ghat)
        {
            GameObject snowfx = Instantiate(snowDestroyVFX, gameObject.transform.position, snowDestroyVFX.transform.rotation);
            GameObject debrisObj = Instantiate(debris, gameObject.transform.position, debris.transform.rotation);
            Destroy(snowfx, 3f);
            Destroy(debrisObj, 3f);
            Destroy(gameObject);
        }
    }
}
