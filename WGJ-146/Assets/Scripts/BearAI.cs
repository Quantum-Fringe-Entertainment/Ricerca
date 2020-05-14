using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using Cinemachine;

public class BearAI : MonoBehaviour
{


    private NavMeshAgent _bearAgent;
    private Transform _Player;
    private Animator _bearAC;
    public PlayableDirector chaseSequence;
    public float minChaseDistance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _bearAgent = GetComponent<NavMeshAgent>();
        _Player = GameObject.FindGameObjectWithTag(Characters.Player).GetComponent<Transform>();
        _bearAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        _bearAgent.SetDestination(_Player.position);
        if (_bearAgent.speed != 0)
            _bearAC.SetBool(AnimalAC_Parameters.isWalking, true);
        else
            _bearAC.SetBool(AnimalAC_Parameters.isWalking, false);



        if(Vector3.Distance(_Player.position,transform.position) < minChaseDistance)
        {
            chaseSequence.Play();
        }

    }
}
