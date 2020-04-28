using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float lookSpeed = 1.5f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 2.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    [HideInInspector] private CharacterController _charController;
    [HideInInspector]private Animator _playerAnim;
    public Camera cam;



    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _playerAnim = GetComponent<Animator>();
        Cursor.visible = false;
    }//Start

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 lookDir = cam.transform.right * x + cam.transform.forward * z; 
        if(lookDir != Vector3.zero)
        {
            //Player Rotation
            Quaternion rotDir = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,// X
                Quaternion.Slerp(transform.rotation, rotDir, Time.deltaTime * lookSpeed).eulerAngles.y, // Y
                transform.rotation.eulerAngles.z)); // Z

            //Player Movement
            moveDirection = transform.forward * moveSpeed * Time.deltaTime;
            _charController.Move(lookDir * moveSpeed * Time.deltaTime);    
        }

    

        if(_charController.isGrounded)
        {
            print("Yeah Bitch Science!!!");
        }




        if (x > 0 || x < 0 || z > 0 || z < 0)
        {
            _playerAnim.SetBool("isWalking", true);
        }
        else
        {
            _playerAnim.SetBool("isWalking", false);
        }
    }//Update

}//class PlayerMovement
