using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.Video;
using System.Collections;
using Cinemachine;

public class PlayerCollisions : MonoBehaviour
{
    public AvalancheSpawnner spawnner;
    public PlayableDirector pettingAndExploringScene;
    public PlayableDirector bearExploringScene;
    public CinemachineVirtualCamera chaseVcam;
    public bool enableChase;
    public GameObject rendetTex;
    public VideoPlayer cavefallSeq;
    public BearAI bearAI;
    public GameObject GameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameTriggers.Avalanche)
            spawnner.spawnAvalanche = true;
        if (other.tag == GameTriggers.StopAvalanche)
            spawnner.spawnAvalanche = false;
        if (other.tag == GameTriggers.Rocks)
        {
            GameOver.SetActive(true);
            gameObject.GetComponent<PlayerState>().currentPlayerState = GetPlayerState.isDead;
            StartCoroutine(GameOverrrrr());
        }
        if (other.tag == GameTriggers.CutScenes.PettingAndExploring)
        {
            pettingAndExploringScene.Play();
            other.gameObject.SetActive(false);
        }

        if (other.tag == GameTriggers.CutScenes.BearExploring)
        { 
            gameObject.GetComponent<PlayerState>().currentPlayerState = GetPlayerState.isExploring;
            bearExploringScene.Play();
        }

        if(other.tag == Characters.Bear)
        {
            //reload the scene from the checkpoint
            gameObject.GetComponent<PlayerState>().currentPlayerState = GetPlayerState.isDead;
        }

        if(other.tag == GameTriggers.CutScenes.CaveFall)
        {
            rendetTex.SetActive(true);
            GetComponent<PlayerState>().PlayerisExploring();
            GetComponent<PlayerState>().enablePlayerInput = false;
            cavefallSeq.Play();
            print("Started playing fall sequnce");
            chaseVcam.Priority = 10;
            bearAI.chaseSequence.Stop();
            bearAI._bearAgent.speed = 0;
            StartCoroutine(ShowCredits());
        }
    }

    IEnumerator ShowCredits()
    {
        yield return new WaitForSeconds((float)cavefallSeq.length + 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator GameOverrrrr()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == GameTriggers.Water)
        {
            GameOver.SetActive(true);
            gameObject.GetComponent<PlayerState>().currentPlayerState = GetPlayerState.isDead;
            StartCoroutine(GameOverrrrr());
        }
    }
}
