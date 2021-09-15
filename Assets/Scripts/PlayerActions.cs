using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigidBody;
    public Vector3 playerPos;

    public bool playerMoving;
    public bool playerIdle;
    public Vector2 lastMove;
    public Vector2 moveInput;

    private static bool playerExists;

    private bool attacking;
    public float attackTime; 
    private float attackTimeCounter;

    public string startPoint;

    //jumping
    public float jumpForce = 6f;
    public LayerMask groundLayer;
    public Vector2 jumpHeight;

    //dialogue
    public DialogueManager dialogueManager;
    public bool canMove;
    public bool isTalking;

    //shooting
    public GameObject projectilePrefab;
    public GameObject crosshair;
    public bool crossHairCreated;
    public bool aiming;
    public Vector2 mousePos;
    public Camera cam;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        playerMoving = false;

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;

        lastMove = new Vector2(0, -1f);

        crosshair.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        crosshair.transform.position = mousePos;
        playerPos = myRigidBody.transform.position;

        if (!canMove)
        {
            //Debug.Log("Cant move");
            myRigidBody.velocity = Vector2.zero;
            playerMoving = false;
            playerIdle = true;
            return;
        }


        if (!attacking || !isTalking || dialogueManager.dialogueActive == false)
        {

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            //Debug.Log(moveInput);
            if (moveInput != Vector2.zero)
            {
                Debug.Log("PlayerIsMoving");
                myRigidBody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                //Debug.Log(myRigidBody.velocity);
                playerMoving = true;
                lastMove = moveInput;
            }
            else if (aiming == true)
            {
                //Debug.Log("IsAiming");
                Aim();
            }
            else
            {
                //Debug.Log("IsntMoving");
                myRigidBody.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidBody.velocity = Vector2.zero;
                //Debug.Log("attacking");
                anim.SetBool("Attack", true);
            }

        }

        //shooting
        if(Input.GetKeyDown(KeyCode.Space))
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
       
            if(aiming == true)
            {
                Vector2 aim = new Vector2(mousePos.x, mousePos.y);
                aim.Normalize();
                aim = aim * 0.70f;
                GameObject projectile = Instantiate(projectilePrefab, playerPos, Quaternion.Euler(0, 0, -45));
                projectile.transform.position = Vector2.MoveTowards(playerPos, aim, 0f);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(aim.x, aim.y) * 10f;
                projectile.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg);
                Destroy(projectile, 3);
            }
            
        }

        //aiming
        if(Input.GetKeyDown(KeyCode.E))
        {
            aiming = true;
            crosshair.SetActive(true);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            aiming = false;
            crosshair.SetActive(false);
            myRigidBody.constraints = RigidbodyConstraints2D.None;
        }

        if (attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            //anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        //anim.SetBool("PlayerMoving", playerMoving);
        anim.SetBool("PlayerIdle", playerIdle);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    
    public void Aim()
    {
        crosshair.SetActive(true);
    }



}
