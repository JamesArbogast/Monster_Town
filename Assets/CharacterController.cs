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
    [SerializeField]
    private float screenBorder;

    private Rigidbody2D rgdbdy2D;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    private Vector2 movementInput;
    public Vector2 animMoveInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    public Vector2 lastMove;
    private bool playerIdle;
    private bool playerMoving;

    [SerializeField]
    private Camera _camera;
    private Animator anim;



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
        _camera = Camera.main;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        animMoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerMoving = true;
            playerIdle = false;
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
        else
        {
            playerIdle = true;
            playerMoving = false;
            anim.SetBool("PlayerIdle", playerIdle);
        }
        lastMove = animMoveInput;
    }

    private void FixedUpdate()
    {
        RotateInDirectionOfInput();
        SetPlayerVelocity();

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
        playerMoving = true;
        PreventPlayerMoveOffScreen();
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

    private void PreventPlayerMoveOffScreen()
    {
        Vector2 screenPos = _camera.WorldToScreenPoint(transform.position);
        //Debug.Log(screenPos.x + ", " + screenPos.y);
        if ((screenPos.x < screenBorder && rgdbdy2D.linearVelocity.x < 0) ||
            (screenPos.x > _camera.pixelWidth - screenBorder && rgdbdy2D.linearVelocity.x > 0))
        {
            rgdbdy2D.linearVelocity = new Vector2(0, rgdbdy2D.linearVelocity.y);
        }

        if ((screenPos.y < screenBorder && rgdbdy2D.linearVelocity.y < 0) ||
            (screenPos.y > _camera.pixelHeight - screenBorder && rgdbdy2D.linearVelocity.y > 0))
        {
            rgdbdy2D.linearVelocity = new Vector2(rgdbdy2D.linearVelocity.x, 0);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
