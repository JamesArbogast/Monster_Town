using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D myRigidbody;
    public Vector2 minWalkPoint;
    public Vector2 maxWalkPoint;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    public float walkCounter;
    public float waitCounter;
    public int walkDirection;
    public bool npcIdle;
    public bool walkingDown;
    public bool walkingUp;
    public bool walkingLeft;
    public bool walkingRight;
    public bool walkingDownLeft;
    public bool walkingDownRight;
    public bool walkingUpLeft;
    public bool walkingUpRight;
    public bool standingIdle;
    public Vector2 lastMove;
    private Animator anim;

    public Collider2D walkZone;
    public bool hasWalkZone;

    public bool canMove;

    //NPC dialogue variables
    public NPCDialogue npcDialogue;
    public DialogueManager dialogueManager;
    public GameObject player;
    private Vector2 playerDirection;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GameObject.Find("NPC").GetComponent<Rigidbody2D>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        npcDialogue = FindObjectOfType<NPCDialogue>();
        player = GameObject.Find("Player");
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
        canMove = true;

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        playerDirection = player.transform.position;

        if(dialogueManager.dialogueActive == true)
        {
            canMove = false;
            npcIdle = true;
        }
        else
        {
            canMove = true;
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    walkingUp = true;
                    walkingDown = false;
                    walkingRight = false;
                    walkingLeft = false;
                    walkingDownLeft = false;
                    walkingDownRight = false;
                    walkingUpLeft = false;
                    walkingUpRight = false;
                    //Debug.Log("NPC Walking Up");
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(0, moveSpeed);
                    }
                    break;

                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    walkingUp = false;
                    walkingDown = false;
                    walkingRight = true;
                    walkingLeft = false;
                    walkingDownLeft = false;
                    walkingDownRight = false;
                    walkingUpLeft = false;
                    walkingUpRight = false;
                    //Debug.Log("NPC Walking Right");
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(moveSpeed, 0);
                    }
                    break;

                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    walkingUp = false;
                    walkingDown = true;
                    walkingRight = false;
                    walkingLeft = false;
                    walkingDownLeft = false;
                    walkingDownRight = false;
                    walkingUpLeft = false;
                    walkingUpRight = false;
                   //Debug.Log("NPC Walking Down");
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(0, -moveSpeed);
                    }
                    break;

                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    walkingUp = false;
                    walkingDown = false;
                    walkingRight = false;
                    walkingLeft = true;
                    walkingDownLeft = false;
                    walkingDownRight = false;
                    walkingUpLeft = false;
                    walkingUpRight = false;
                    //Debug.Log("NPC Walking Left");
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(-moveSpeed, 0);
                    }
                    break;

                case 4:
                    myRigidbody.velocity = new Vector2(-moveSpeed, -moveSpeed);
                    walkingUp = false;
                    walkingDown = false;
                    walkingRight = false;
                    walkingLeft = false;
                    walkingDownLeft = true;
                    walkingDownRight = false;
                    walkingUpLeft = false;
                    walkingUpRight = false;
                    //Debug.Log("NPC Walking Down Left");
                    /*if (hasWalkZone && (transform.position.x < minWalkPoint.x || transform.position.y < minWalkPoint.y))
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(-moveSpeed, -moveSpeed);
                    }*/
                    break;

                case 5:
                    myRigidbody.velocity = new Vector2(moveSpeed, -moveSpeed);
                    walkingUp = false;
                    walkingDown = false;
                    walkingRight = false;
                    walkingLeft = false;
                    walkingDownLeft = false;
                    walkingDownRight = true;
                    walkingUpLeft = false;
                    walkingUpRight = false;
                    //Debug.Log("NPC Walking Down Right");
                    /*if (hasWalkZone && (transform.position.x > minWalkPoint.x || transform.position.y < minWalkPoint.y))
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(moveSpeed, -moveSpeed);
                    }*/
                    break;

                case 6:
                    myRigidbody.velocity = new Vector2(-moveSpeed, moveSpeed);
                    walkingUp = false;
                    walkingDown = false;
                    walkingRight = false;
                    walkingLeft = false;
                    walkingDownLeft = false;
                    walkingDownRight = false;
                    walkingUpLeft = true;
                    walkingUpRight = false;
                    //Debug.Log("NPC Walking Up Left");
                    /*if (hasWalkZone && (transform.position.x < minWalkPoint.x || transform.position.y > minWalkPoint.y))
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(-moveSpeed, moveSpeed);
                    }*/
                    break;

                case 7:
                    myRigidbody.velocity = new Vector2(moveSpeed, moveSpeed);
                    walkingUp = false;
                    walkingDown = false;
                    walkingRight = false;
                    walkingLeft = false;
                    walkingDownLeft = false;
                    walkingDownRight = false;
                    walkingUpLeft = false;
                    walkingUpRight = true;
                    //Debug.Log("NPC Walking Up Right");
                    /*if (hasWalkZone && (transform.position.x > minWalkPoint.x || transform.position.y > minWalkPoint.y))
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        lastMove = new Vector2(moveSpeed, moveSpeed);
                    }*/
                    break;

            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }

        //anim.SetBool("NPCIdle", npcIdle);
        anim.SetBool("MovingDown", walkingDown);
        anim.SetBool("MovingUp", walkingUp);
        anim.SetBool("MovingLeft", walkingLeft);
        anim.SetBool("MovingRight", walkingRight);
        anim.SetBool("MovingDownLeft", walkingDownLeft);
        anim.SetBool("MovingDownRight", walkingDownRight);
        anim.SetBool("MovingUpRight", walkingUpRight);
        anim.SetBool("MovingUpLeft", walkingUpLeft);


    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 8);
        isWalking = true;
        walkCounter = walkTime;
    }

    public void FaceDirection()
    {
        if(transform.position.x < playerDirection.x)
        {

        }
    }
}
