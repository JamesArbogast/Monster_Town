using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator anim;


    //extra movements
    private Vector3 slideDir;
    private Vector3 newSpot;
    private float slideSpeed;
    private State state;

    //attacks
    public GameObject projectile;
    private enum State
    {
        Normal,
        DodgeRollSliding,
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        //fix to left movement sprites
        if (movement.x == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        switch(state)
        {
            case State.Normal:
                //dodge roll
                HandleDodgeRoll();
                break;
            case State.DodgeRollSliding:
                HandleDodgeRollSliding();
                break;
        }

        //roll directions
        if (movement.y == -1 && movement.x == -1)
        {
            newSpot = new Vector2(transform.position.x - .8f, transform.position.y - .8f);
        }
        else if (movement.y == 1 && movement.x == 1)
        {
            newSpot = new Vector2(transform.position.x + .8f, transform.position.y + .8f);
        }
        else if (movement.y == 1 && movement.x == - 1)
        {
            newSpot = new Vector2(transform.position.x - .8f, transform.position.y + .8f);
        }
        else if (movement.y == -1 && movement.x == 1)
        {
            newSpot = new Vector2(transform.position.x + .8f, transform.position.y - .8f);
        }
        else if (movement.x == -1)
        {
            newSpot = new Vector2(transform.position.x - 1, transform.position.y);
        }
        else if (movement.y == 1)
        {
            newSpot = new Vector2(transform.position.x, transform.position.y + 1);
        }
        else if (movement.y == -1)
        {
            newSpot = new Vector2(transform.position.x, transform.position.y - 1);
        }
        else if(movement.x == 1)
        {
            newSpot = new Vector2(transform.position.x + 1, transform.position.y);
        }

        //projectile
        if(Input.GetButtonDown("SecondWeapon"))
        {

        }

    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void HandleDodgeRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            state = State.DodgeRollSliding;
            slideDir = (newSpot - transform.position).normalized;
            slideSpeed = 50f;
        }
    }

    private void HandleDodgeRollSliding()
    {
        transform.position += slideDir * slideSpeed * Time.deltaTime;
        slideSpeed -= slideSpeed * 10f * Time.deltaTime;
        if(slideSpeed < 5f)
        {
            state = State.Normal;
        }
    }
}
