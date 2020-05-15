using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Checkpoints
{
    MountainBottom = 0,
    MountainTop,
    Cave,
    Ledges,
    Slope
}


public class PlayerDamage : MonoBehaviour
{
    public Transform[] respawnCheckpoints;
    public Checkpoints lastCheckpoint;

    private void Start()
    {
        SetRespawnPosition();
    }


    void SetRespawnPosition()
    {
        //transform.position = respawnCheckpoints[(int)Checkpoints.MountainTop].position;
    }

    public void UpdateLastCheckpoint(Checkpoints m_checkpoint)
    {
        lastCheckpoint = m_checkpoint;
    }

    public void RespawnPlayer()
    {
        // Need to finish defining it later
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
