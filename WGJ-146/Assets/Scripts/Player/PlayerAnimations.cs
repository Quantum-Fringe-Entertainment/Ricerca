using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAnimations : MonoBehaviour
{
    private Animator m_playerAnim;
    public PlayableDirector stumbleScene;
    // Start is called before the first frame update
    void Start()
    {
        m_playerAnim = GetComponent<Animator>();
    }

    public void StartWalking()
    {
        m_playerAnim.SetBool(PlayerAC_Parameters.isWalking, true);
    }

    public void StopWalking()
    {
        m_playerAnim.SetBool(PlayerAC_Parameters.isWalking, false);
    }

    public void Stumble()
    {
        //m_playerAnim.SetTrigger(PlayerAC_Parameters.Stumble);
        stumbleScene.Play();
    }
}
