using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour
{
    public List<GameObject> Spikes;
    public Transform Dummy;

    public bool SpikesGrounded = false;

    //private int _spikesTouched = 0;

    public int SpikesDetected = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Spikes = new List<GameObject>();
        foreach(GameObject spike in Spikes)
        {
            spike.transform.position = Dummy.transform.position;
        }

        SpawnSpikes();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpikesGrounded)
        {
            SpikesDetected = 0;
           // _spikesTouched = 0;
            SpawnSpikes();
        }

        CheckSpikesGrounded();
        
    }

    public void SpawnSpikes()
    {
        foreach (GameObject spike in Spikes)
        {
            spike.transform.position = new Vector3(Random.Range(-3,83), 20, Random.Range(39, 139));
        }
        SpikesGrounded = false;
    }

    public void CheckSpikesGrounded()
    {
        if (SpikesDetected==20)
        {
            
            SpikesGrounded = true;
        }

       

        else
        {
            return;
        }


    }

   
    

}
