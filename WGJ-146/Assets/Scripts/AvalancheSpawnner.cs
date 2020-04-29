using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheSpawnner : MonoBehaviour
{
    public float heightOffset = 2f;
    public float spawnDistanceMax = 8f;
    public float spawnDistanceMin = 5f;
    public float spawnRate = 2;
    [Space]
    public GameObject avalancheprefab;
    [Space]
    public GameObject player;

    private float t = 0f;
    private void Update()
    {
        Vector3 spawnLocation = player.transform.position + player.transform.forward * Random.Range(spawnDistanceMin,spawnDistanceMax);
        spawnLocation.y = transform.position.y + heightOffset;

        if (t > spawnRate)
        {
            GameObject snow = Instantiate(avalancheprefab, spawnLocation, player.transform.rotation);
            Destroy(snow, 10f);
            t = 0;
        }
        t += Time.deltaTime;
      

    }



}
