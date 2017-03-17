using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void DetectMovement()
    {
        if (rb.velocity == Vector3.zero)
            anim.SetBool("isMoving", false);

        else
            anim.SetBool("isMoving", true);
    }

}
