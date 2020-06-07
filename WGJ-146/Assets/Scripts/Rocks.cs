using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public GameObject snowDestroyVFX;
    public GameObject brokenVariant;
    public float destructionForce = 2f;
    public GameObject breaking;

    private void Start()
    {
        breaking = GameObject.FindGameObjectWithTag(SFX.breaking);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == GameTriggers.Ghat)
        {
            breaking.GetComponent<AudioSource>().Play();
            GameObject snowfx = Instantiate(snowDestroyVFX, gameObject.transform.position, snowDestroyVFX.transform.rotation);
            GameObject debrisObj = Instantiate(brokenVariant, gameObject.transform.position, brokenVariant.transform.rotation);
            foreach (Rigidbody debrisRB in debrisObj.GetComponentsInChildren<Rigidbody>())
            {
                debrisRB.AddForce(Vector3.one * destructionForce);
            }
            Destroy(snowfx, 3f);
            Destroy(debrisObj, 10f);
            Destroy(gameObject);
        }
    }
}
