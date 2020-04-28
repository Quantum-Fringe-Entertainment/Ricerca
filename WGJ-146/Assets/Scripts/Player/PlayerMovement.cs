﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float lookSpeed = 1.5f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 3f;
    public float gravityRelaxation = 0.6f;
    private Vector3 moveDirection = Vector3.zero;

    [HideInInspector] private CharacterController _charController;
    [HideInInspector] private Animator _playerAnim;
    public Camera cam;

    private float t = 1f;
    private bool jumpMaar = false;


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

        if (Input.GetButtonDown("Jump") && _charController.isGrounded)
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


        if (x > 0 || x < 0 || z > 0 || z < 0)
        {
            _playerAnim.SetBool("isWalking", true);
        }
        else
        {
            _playerAnim.SetBool("isWalking", false);
        }

        if (jumpMaar && t <= 0.08)
        {
            moveDirection.y = Mathf.Lerp(moveDirection.y, -Physics.gravity.y * 0.1f, t);
            //print(Mathf.Lerp(moveDirection.y, -Physics.gravity.y, t));
            t += 0.15f * Time.deltaTime;

        }

        print(moveDirection);
        _charController.Move(moveDirection);


    }//Update


}//class PlayerMovement
