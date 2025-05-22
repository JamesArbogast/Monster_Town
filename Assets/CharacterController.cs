using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : BasePlayer
{
    [SerializeField] 
    public float speed;
    [SerializeField]
    private float rotationSpeed;
    private Rigidbody2D rgdbdy2D;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;


    /*
    [SerializeField] private LayerMask dashLayerMask;
    private Vector2 moveSpeed;
    private Vector3 curMoveDir;
    private Vector3 lastMoveDir;
    private Animator anim;
    private bool isDashActive;
    */
    private void Awake()
    {
        rgdbdy2D = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    /*
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
        lastMoveDir = dir;
        if(lastMoveDir == new Vector3(+1f,0,0))
        {
            anim.Play("IdleRight");
        }
        //gameObject.transform.LookAt(lookDirection);
    }
    */

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();

        /*
        if(isDashActive)
        {
            float dashAmnt = 10f;
            Vector3 dashPosition = transform.position + curMoveDir * dashAmnt;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, curMoveDir, dashAmnt, dashLayerMask);
            if(raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }
            isDashActive = false;
        }
        */
    }
    void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref movementInputSmoothVelocity,
            0.1f);

        rgdbdy2D.linearVelocity = smoothedMovementInput * speed;
    }

    private void RotateInDirectionOfInput()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rgdbdy2D.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
