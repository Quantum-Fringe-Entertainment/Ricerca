using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheSpawnner : MonoBehaviour
{
    public float heightOffset = 5f;
    public float spawnDistanceMax = 8f;
    public float spawnDistanceMin = 5f;
    public float spawnRate = 1;
    [Space]
    public GameObject[] avalancheRocks;
    [Space]
    public GameObject player;
    [Space]
    public bool spawnAvalanche;


    private float t = 0f;
    private void Update()
    {
        if (spawnAvalanche)
        {
            Vector3 spawnLocation = player.transform.position + player.transform.forward * Random.Range(spawnDistanceMin, spawnDistanceMax);
            spawnLocation.y = transform.position.y + heightOffset;

            if (t > spawnRate)
            {
                GameObject snow = Instantiate(avalancheRocks[Random.Range(0,avalancheRocks.Length - 1)], spawnLocation, player.transform.rotation);
                Destroy(snow, 10f);
                t = 0;
            }
            t += Time.deltaTime;
        }
    }
}
