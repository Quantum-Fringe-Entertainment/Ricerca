using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public float lookSpeed = 1.5f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 3f;
    public float gravityRelaxation = 0.6f;
    public Camera cam;
    public CinemachineFreeLook mainPlayerCamera;



    [HideInInspector] private CharacterController _charController;
    [HideInInspector] private PlayerState playerState;
    private Vector3 moveDirection = Vector3.zero;
    private float t = 1f;
    private bool jumpMaar = false;
    private float x;
    private float z;


    
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
        Cursor.visible = false;
    }//Start

    private void Update()
    {
         x = Input.GetAxis(Axis.Horizontal);
         z = Input.GetAxis(Axis.Vertical);



        GetPlayerDirection();
        JumpAndGravity();
        DisableCamControl();

        _charController.Move(moveDirection);


    }//Update


    void GetPlayerDirection()
    {
        moveDirection = cam.transform.right * x + cam.transform.forward * z;
        if (moveDirection != Vector3.zero && (playerState.enablePlayerInput))
        {
            //Player Rotation
            Quaternion rotDir = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,// X
                Quaternion.Slerp(transform.rotation, rotDir, Time.deltaTime * lookSpeed).eulerAngles.y, // Y
                transform.rotation.eulerAngles.z)); // Z

            //Player Movement
            moveDirection = transform.forward * moveSpeed * Time.deltaTime;

        }
        else
            moveDirection = Vector3.zero;

    }

    void DisableCamControl()
    {
        if (!playerState.enablePlayerInput)
        {
            //mainPlayerCamera.m_XAxis.Value = 0f;
            //mainPlayerCamera.m_YAxis.Value = 0f;
            mainPlayerCamera.m_YAxis.m_InputAxisName = "";
            mainPlayerCamera.m_XAxis.m_InputAxisName = "";
        }
        else
        {
            mainPlayerCamera.m_YAxis.m_InputAxisName = "Mouse Y";
            mainPlayerCamera.m_XAxis.m_InputAxisName = "Mouse X";
        }
    }

    void JumpAndGravity()
    {
        if (Input.GetButtonDown(Axis.Jump) && _charController.isGrounded)
        {
            //moveDirection.y -= Physics.gravity.y * Time.deltaTime * jumpSpeed;
            jumpMaar = true;
            t = 0;
        }
        else if (t >= 0.075f)
        {
            jumpMaar = false;
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityRelaxation;
        }

        if (jumpMaar && t <= 0.08)
        {
            moveDirection.y = Mathf.Lerp(moveDirection.y, -Physics.gravity.y * 0.1f, t);
            //print(Mathf.Lerp(moveDirection.y, -Physics.gravity.y, t));
            t += 0.15f * Time.deltaTime;

        }
    }


}//class PlayerMovement
