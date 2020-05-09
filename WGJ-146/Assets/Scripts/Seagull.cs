using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{

    public float flyawayRange = 5f;

    private Animator _seagullAC;
    // Start is called before the first frame update
    void Start()
    {
        _seagullAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position,flyawayRange,Vector3.forward * -1,out RaycastHit hitInfo))
        {
            print(hitInfo.collider.name);

            if (hitInfo.collider.tag == Characters.Player)
            {
                Debug.Log("Ahh fuck Humans!!!!");
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, flyawayRange);
    }
}


