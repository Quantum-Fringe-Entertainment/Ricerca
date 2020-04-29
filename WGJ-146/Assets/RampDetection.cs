using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampDetection : MonoBehaviour
{
    public SpikePool SpikesRespawn;
    // Start is called before the first frame update
    void Start()
    {
        SpikesRespawn = GameObject.FindGameObjectWithTag("SpikeCollection").GetComponent<SpikePool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            SpikesRespawn.SpikesDetected++;
        }
    }
}
