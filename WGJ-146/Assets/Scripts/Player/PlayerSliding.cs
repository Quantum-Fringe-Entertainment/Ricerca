using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSliding : MonoBehaviour
{
   // public float lookSpeed = 1.5f;
   // public float moveSpeed = 5f;
    [HideInInspector] private CharacterController _charController;
    [HideInInspector] private Animator _playerAnim;
    private ParticleSystem _SnowEffect;
   // public Camera cam;



    [Header("Slope Settings")]
    [SerializeField]
    private float _RayLength = 2f;
    [SerializeField]
    private float _SlopeForce = 5f;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _playerAnim = GetComponent<Animator>();
        _SnowEffect = GetComponentInChildren<ParticleSystem>();
        _SnowEffect.Pause();
        // Cursor.visible = false;
    }//Start

    private void Update()
    {
       // float x = Input.GetAxis("Horizontal");
       // float z = Input.GetAxis("Vertical");

       

      //  Vector3 moveDir = cam.transform.right * x + cam.transform.forward * z;
       // if (moveDir != Vector3.zero)
       // {
            //Player Rotation
         //   Quaternion rotDir = Quaternion.LookRotation(moveDir);
          //  transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,// X
           //     Quaternion.Slerp(transform.rotation, rotDir, Time.deltaTime * lookSpeed).eulerAngles.y, // Y
            //    transform.rotation.eulerAngles.z)); // Z

            //Player Movement
           // _charController.Move(transform.forward * moveSpeed * Time.deltaTime);



        


       // if (x > 0 || x < 0 || z > 0 || z < 0)
       // {
       //     _playerAnim.SetBool("isWalking", true);
       // }
       // else
       // {
       //     _playerAnim.SetBool("isWalking", false);
       // }

        if (OnSlope())
        {
            _charController.Move(Vector3.down * _charController.height / 2 * _SlopeForce * Time.deltaTime);

            //transform.position += transform.forward * _charController.height / 2 * _SlopeForce * Time.deltaTime;

            _charController.Move(transform.forward * _charController.height / 2 * _SlopeForce * Time.deltaTime);

           // transform.Translate(Vector3.forward);

           // transform.position = transform.forward * _SlopeForce * Time.deltaTime;

            // transform.Translate(Vector3.forward);

        }
        else
        {
            return;
        }


    }//Update

    private bool OnSlope()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, _charController.height / 2 * _RayLength))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }


        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Entry"))
        {
            _playerAnim.SetTrigger("SlopeStarts");
            // z = 1;
            _SnowEffect.Play();

        }

        if (other.CompareTag("Exit"))
        {
            _playerAnim.SetTrigger("SlopeEnds");
            _SnowEffect.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            gameObject.SetActive(false);
        }
    }




}//class PlayerSliding

