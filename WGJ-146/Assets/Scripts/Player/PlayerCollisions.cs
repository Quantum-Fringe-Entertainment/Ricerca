using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class PlayerCollisions : MonoBehaviour
{
    public AvalancheSpawnner spawnner;
    public PlayableDirector pettingAndExploringScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameTriggers.Avalanche)
            spawnner.spawnAvalanche = true;
        if(other.tag == GameTriggers.StopAvalanche)
            spawnner.spawnAvalanche = false;
        if (other.tag == GameTriggers.Rocks)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (other.tag == GameTriggers.CutScenes.PettingAndExploring)
        {
            pettingAndExploringScene.Play();
            other.gameObject.SetActive(false);
        }

    }
}
