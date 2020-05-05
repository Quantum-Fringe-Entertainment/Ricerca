using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float lookSpeed = 1.5f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 3f;
    public float gravityRelaxation = 0.6f;
    public Camera cam;
    public Transform stumbleCheckPoint;
    public float rayLength = 2f;

    [HideInInspector] private CharacterController _charController;
    [HideInInspector] private PlayerAnimations playerAnimations;
    private Vector3 moveDirection = Vector3.zero;
    private float t = 1f;
    private bool jumpMaar = false;
    private float x;
    private float z;


    
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<PlayerAnimations>();
        Cursor.visible = false;
    }//Start

    private void Update()
    {
         x = Input.GetAxis(Axis.Horizontal);
         z = Input.GetAxis(Axis.Vertical);



        GetPlayerDirection();
        JumpAndGravity();
        SetPlayerAnimations();

        _charController.Move(moveDirection);


    }//Update


    void GetPlayerDirection()
    {
        moveDirection = cam.transform.right * x + cam.transform.forward * z;
        if (moveDirection != Vector3.zero)
        {
            //Player Rotation
            Quaternion rotDir = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,// X
                Quaternion.Slerp(transform.rotation, rotDir, Time.deltaTime * lookSpeed).eulerAngles.y, // Y
                transform.rotation.eulerAngles.z)); // Z

            //Player Movement
            moveDirection = transform.forward * moveSpeed * Time.deltaTime;

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

    void SetPlayerAnimations()
    {
        if (x > 0 || x < 0 || z > 0 || z < 0)
        {
            playerAnimations.StartWalking();
        }
        else
        {
            playerAnimations.StopWalking();
        }

        if(Physics.Raycast(stumbleCheckPoint.position,transform.forward,out RaycastHit raycastHitForward,rayLength))
        {
            Debug.DrawLine(stumbleCheckPoint.position, raycastHitForward.point, color: Color.black);
            if(raycastHitForward.collider.tag == GameTriggers.Rocks)
            {
                print("Damn the Rock!!!!");
                playerAnimations.Stumble();
            }
        }
        if (Physics.Raycast(stumbleCheckPoint.position, transform.right, out RaycastHit raycastHitRight, rayLength))
        {
            Debug.DrawLine(stumbleCheckPoint.position, raycastHitRight.point, color: Color.black);
            if (raycastHitRight.collider.tag == GameTriggers.Rocks)
            {
                print("Damn the Rock!!!!");
                playerAnimations.Stumble();
            }
        }
    }

}//class PlayerMovement
