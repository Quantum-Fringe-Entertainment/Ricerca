using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMechanics : MonoBehaviour
{
    [Header("Ledge Testing")]
    public bool LedgeMechanic = false;
    public Transform LedgeTest;
    [Space]
    [Header("Spike Testing")]
    public bool SpikeMechanic = false;
    public Transform SpikeTest;


    public bool SetLocation = false;

    
    public void Update()
    {
        if (SetLocation == false)
        {
            if (LedgeMechanic == true)
            {
                this.transform.position = LedgeTest.position;
                SetLocation = true;
            }
            if (SpikeTest == true)
            {
                this.transform.position = SpikeTest.position;
                SetLocation = true;
            }

            else
            {
                return;
            }

        }
    }
}
