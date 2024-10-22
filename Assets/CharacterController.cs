using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const float MOVE_SPEED = 10f;
    private Rigidbody2D rgdbdy2D;
    private Vector2 moveSpeed;
    private Vector3 moveDir;
    private Animator anim;

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
        moveDir = new Vector3(moveX, moveY).normalized;

        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
        //Input
        moveSpeed.x = Input.GetAxisRaw("Horizontal");
        moveSpeed.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", moveSpeed.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rgdbdy2D.velocity = moveDir * MOVE_SPEED;
    }
}
