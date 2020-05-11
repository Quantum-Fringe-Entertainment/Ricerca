using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMechanics : MonoBehaviour
{
    [Header("Ledge Testing")]
    public bool LedgeMechanic;
    public Transform LedgeTest;
    [Space]
    [Header("Spike Testing")]
    public bool SpikeMechanic;
    public Transform SpikeTest;

    public void Awake()
    {
        if (LedgeMechanic == true) {
            transform.position = LedgeTest.position;
        }
        if (SpikeTest == true)
        {
            transform.position = SpikeTest.position;
        }
       
    }
}
