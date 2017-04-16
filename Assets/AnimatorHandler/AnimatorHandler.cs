using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour {

    private Animator anim;
    private CharacterController controller;

    private bool isMoving;
    private bool isSprinting;
    public float speedMultiplierBase = 1f;
    public float speedMultiplierIncreased = 2f;
    private string jump;
    private bool isDead = false;
    public string[] attacks;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        DetectMovement();
    }

    public void SpeedIncreased()
    {
        anim.SetFloat("speedMultiplier", speedMultiplierIncreased);
        isSprinting = true;
    }

    public void SpeedNormal()
    {
        anim.SetFloat("speedMultiplier", speedMultiplierBase);
        isSprinting = false;
    }

    public void TriggerJump()
    {
        if (jump != null || jump != "")
            anim.SetTrigger(jump);
        else
            anim.SetTrigger("jump");
    }


    public void TriggerAttack(string attackType)
    {
        anim.SetTrigger(attackType);
    }

    private void DetectMovement()
    {
        if (controller.velocity == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;

        anim.SetBool("isMoving", isMoving);

        
    }

}
