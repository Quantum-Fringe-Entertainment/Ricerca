using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;


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
    isStandingUp,
    isPettingAndExploring,
    isBeingChased
}

public class PlayerState : MonoBehaviour
{
    private Animator m_playerAnim;
    public PlayableDirector stumbleScene;
    public GetPlayerState currentPlayerState;
    public Transform stumbleCheckPoint;
    public float stumbleRayLength = 2f;
    public CinemachineFreeLook mainPlayerCamera;

    private float x;
    private float z;

    void Start()
    {
        m_playerAnim = GetComponent<Animator>();
        currentPlayerState = GetPlayerState.isIdle;
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
        currentPlayerState = GetPlayerState.isStandingUp;
    }

    public void PlayerStoodUp()
    {
        currentPlayerState = GetPlayerState.isIdle;
    }

    public void PettingAndExploring()
    {
        currentPlayerState = GetPlayerState.isPettingAndExploring;
    }

    private void Update()
    {

        x = Input.GetAxis(Axis.Horizontal);
        z = Input.GetAxis(Axis.Vertical);



        SetPlayerAnimations();
        DisableCamControl();

    }


    void SetPlayerAnimations()
    {
        if (( currentPlayerState != GetPlayerState.isStumbling) && ( currentPlayerState != GetPlayerState.isStandingUp) && (currentPlayerState != GetPlayerState.isPettingAndExploring))
        {

            if (x > 0 || x < 0 || z > 0 || z < 0)
            {
                 StartWalking();
                 currentPlayerState = GetPlayerState.isWalking;
            }
            else
            {
                 StopWalking();
                 currentPlayerState = GetPlayerState.isIdle;
            }
        }


        if (Physics.Raycast(stumbleCheckPoint.position, transform.forward, out RaycastHit raycastHitForward, stumbleRayLength))
        {
            Debug.DrawLine(stumbleCheckPoint.position, raycastHitForward.point, color: Color.black);
            if (raycastHitForward.collider.tag == GameTriggers.Rocks)
            {
                 Stumble();
                 currentPlayerState = GetPlayerState.isStumbling;

            }
        }
        if (Physics.Raycast(stumbleCheckPoint.position, transform.right, out RaycastHit raycastHitRight, stumbleRayLength))
        {
            Debug.DrawLine(stumbleCheckPoint.position, raycastHitRight.point, color: Color.black);
            if (raycastHitRight.collider.tag == GameTriggers.Rocks)
            {
                 Stumble();
                 currentPlayerState = GetPlayerState.isStumbling;
            }
        }

        if (Physics.Raycast(stumbleCheckPoint.position, -transform.right, out RaycastHit raycastHitLeft, stumbleRayLength))
        {
            Debug.DrawLine(stumbleCheckPoint.position, raycastHitLeft.point, color: Color.black);
            if (raycastHitLeft.collider.tag == GameTriggers.Rocks)
            {
                Stumble();
                currentPlayerState = GetPlayerState.isStumbling;

            }
        }
    }

    void DisableCamControl()
    {
        if (( currentPlayerState == GetPlayerState.isStumbling) || ( currentPlayerState == GetPlayerState.isStandingUp) || (currentPlayerState == GetPlayerState.isPettingAndExploring))
        {
            mainPlayerCamera.m_YAxis.m_InputAxisName = "";
            mainPlayerCamera.m_XAxis.m_InputAxisName = "";
        }
        else
        {
            mainPlayerCamera.m_YAxis.m_InputAxisName = "Mouse Y";
            mainPlayerCamera.m_XAxis.m_InputAxisName = "Mouse X";
        }
    }

}
