using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeMovement : MonoBehaviour
{
    [HideInInspector] private CharacterController _charController;
    [HideInInspector] private Animator _playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  //  private void OnCollisionEnter(Collision collision)
   // {
     //   if (collision.gameObject.CompareTag("ledgewall"))
       // {
         //   _playerAnim.SetTrigger("LedgeWall");
       // }
   // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ledgewall"))
        {
            _playerAnim.SetTrigger("LedgeWall");
        }
        if (other.CompareTag("ledgeend"))
        {
            _playerAnim.SetTrigger("LedgeEnd");
        }
    }



}
