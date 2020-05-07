using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[HideInInspector]
 public enum GetPlayerState
{
    isIdle,
    isWalking,
    isRunning,
    isJumping,
    isGrabbingLedge,
    isDead,
    isStumbling,
    isStandingUp
}

public class PlayerState : MonoBehaviour
{
    private Animator m_playerAnim;
    public PlayableDirector stumbleScene;
    public GetPlayerState currentPlayerState;

    void Start()
    {
        m_playerAnim = GetComponent<Animator>();
        currentPlayerState = GetPlayerState.isStandingUp;
    }

    public void StartWalking()
    {
        m_playerAnim.SetBool(PlayerAC_Parameters.isWalking, true);
        currentPlayerState = GetPlayerState.isWalking;
    }

    public void StopWalking()
    {
        m_playerAnim.SetBool(PlayerAC_Parameters.isWalking, false);
        currentPlayerState = GetPlayerState.isIdle;
    }

    public void Stumble()
    {
        stumbleScene.Play();
        currentPlayerState = GetPlayerState.isStumbling;
    }

    public void PlayerIsStandingUp()
    {
        print("Kumbaaya!!!!");
        currentPlayerState = GetPlayerState.isStandingUp;
    }

    public void PlayerStoodUp()
    {
        print("BC !!  nahiiii");
        currentPlayerState = GetPlayerState.isIdle;
    }

    private void Update()
    {
        print(currentPlayerState);
    }
}
