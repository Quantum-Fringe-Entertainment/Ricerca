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
    #region Never change these 2 States
    isStumbling,
    isStandingUp,
    #endregion
    isExploring,
    isBeingChased// this is same as "isSprinting" param in AC parameters for the player
}


public class PlayerState : MonoBehaviour
{
    public PlayableDirector stumbleScene;
    public GetPlayerState currentPlayerState;
    public Transform stumbleCheckPoint;
    public float stumbleRayLength = 2f;

    [HideInInspector] public bool enablePlayerInput = true;

    private Animator m_playerAnim;
    private float x;
    private float z;
    private bool enableChase;

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

    public void StartSprinting()
    {
        m_playerAnim.SetBool(PlayerAC_Parameters.isSprinting, true);
        currentPlayerState = GetPlayerState.isBeingChased;
    }

    public void StopSprinting()
    {
        m_playerAnim.SetBool(PlayerAC_Parameters.isSprinting, false);
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

    public void PlayerisExploring()
    {
        currentPlayerState = GetPlayerState.isExploring;
    }

    public void MakePlayerAnimationIdle()
    {
        m_playerAnim.SetBool(PlayerAC_Parameters.isSprinting, false);
        m_playerAnim.SetBool(PlayerAC_Parameters.isWalking, false);
    }

    public void BeingChased()
    {
        enableChase = true;
    }

    private void Update()
    {

        x = Input.GetAxis(Axis.Horizontal);
        z = Input.GetAxis(Axis.Vertical);

        CheckPlayerStatus();
        SetPlayerAnimations();


        if (enableChase)
            currentPlayerState = GetPlayerState.isBeingChased;
    }

    void CheckPlayerStatus()
    {
        if ((currentPlayerState != GetPlayerState.isStumbling)
            && (currentPlayerState != GetPlayerState.isStandingUp)
            && (currentPlayerState != GetPlayerState.isExploring))
        {
            enablePlayerInput = true;
        }
        else if ((currentPlayerState == GetPlayerState.isStumbling)
                 || (currentPlayerState == GetPlayerState.isStandingUp)
                 || (currentPlayerState == GetPlayerState.isExploring))
             {
                enablePlayerInput = false;
                MakePlayerAnimationIdle();
             }

    }

    void SetPlayerAnimations()
    {
        if(currentPlayerState != GetPlayerState.isBeingChased && enablePlayerInput)
        {
            StopSprinting();

                if (x > 0 || x < 0 || z > 0 || z < 0)
                {
                    StartWalking();
                }
                else
                {
                    StopWalking();
                }
        }
        else if (currentPlayerState == GetPlayerState.isBeingChased && enablePlayerInput)
        {
            StopWalking();

                if (x > 0 || x < 0 || z > 0 || z < 0)
                {
                    StartSprinting();
                }
                else
                {
                    StopSprinting();
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

    

}
