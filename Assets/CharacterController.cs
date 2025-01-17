﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const float MOVE_SPEED = 10f;
    private Rigidbody2D rgdbdy2D;
    private Vector2 moveSpeed;
    private Vector3 curMoveDir;
    private Vector3 lastMoveDir;
    private Animator anim;
    private bool isDashActive;

    private void Awake()
    {
        rgdbdy2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        // normalized move direction
        curMoveDir = new Vector3(moveX, moveY).normalized;
        Debug.Log(curMoveDir);

        //setting animation logic for character movement
        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
        //Input
        moveSpeed.x = Input.GetAxisRaw("Horizontal");
        moveSpeed.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", moveSpeed.sqrMagnitude);
        lastMoveDir = curMoveDir;

        if (curMoveDir != new Vector3(0, 0, 0))
        {
            //End movment with character face direction
            SetFaceDirection(curMoveDir);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDashActive = true;
        }
    }

    private void SetFaceDirection(Vector3 dir)
    {
        //Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Debug.Log(dir);
        lastMoveDir = dir;
        if(lastMoveDir == new Vector3(+1f,0,0))
        {
            anim.Play("IdleRight");
        }
        //gameObject.transform.LookAt(lookDirection);
    }

    private void FixedUpdate()
    {
        rgdbdy2D.velocity = curMoveDir * MOVE_SPEED;

        if(isDashActive)
        {
            float dashAmnt = 10f;
            rgdbdy2D.MovePosition(transform.position + curMoveDir * dashAmnt);
            isDashActive = false;
        }
    }
}
