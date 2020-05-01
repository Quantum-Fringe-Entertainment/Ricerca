using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public AvalancheSpawnner spawnner;

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag == GameTriggers.Avalanche)
            spawnner.spawnAvalanche = true;
    }
}
