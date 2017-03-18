using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {

    private Rigidbody rb;
    private Animator anim;
    private CharacterController controller;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void DetectMovement()
    {
        // possible controller.velocity  , agent.velocity
        if (rb.velocity == Vector3.zero)
            anim.SetBool("isMoving", false);

        else
            anim.SetBool("isMoving", true);
    }

}
