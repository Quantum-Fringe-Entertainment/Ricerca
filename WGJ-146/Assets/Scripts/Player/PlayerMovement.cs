using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float lookSpeed = 1.5f;
    public float moveSpeed = 5f;
    [HideInInspector]private CharacterController _charController;
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

        Vector3 moveDir = cam.transform.right * x + cam.transform.forward * z; 
        if(moveDir != Vector3.zero)
        {
            //Player Rotation
            Quaternion rotDir = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,// X
                Quaternion.Slerp(transform.rotation, rotDir, Time.deltaTime * lookSpeed).eulerAngles.y, // Y
                transform.rotation.eulerAngles.z)); // Z

            //Player Movement
            _charController.Move(transform.forward * moveSpeed * Time.deltaTime);


           
        }


        if(x > 0 || x < 0 || z > 0 || z < 0)
        {
            _playerAnim.SetBool("isWalking", true);
        }
        else
        {
            _playerAnim.SetBool("isWalking", false);
        }

       
    }//Update

   


}//class PlayerMovement
