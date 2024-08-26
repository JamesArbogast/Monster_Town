using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BasePlayer
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

    //UI manager
    public UIManager uim;


    //attacks
    public GameObject projectile;
    private enum State
    {
        Normal,
        DodgeRollSliding,
        Attacking,
        Interact
    }

    //health
    public float maxHealth = 100f;
    public float minHealth = 0;
    public float curHealth = 100f;

    //energy
    public float maxEng = 100f;
    public float minEng = 0;
    public float curEng = 100f;

    //stamina
    public float maxStam = 100f;
    public float minStam = 0;
    public float curStam = 100f;

    private void Start()
    {
        
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
        if(Input.GetKeyDown("space"))
        {
            StartCoroutine(ProjectileAttack());
        }

    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //attacks
    private IEnumerator ProjectileAttack()
    {
        Debug.Log("Weapon fired!");
        //anim.SetBool("isAttacking", true);
        state = State.Attacking;
        Projectiles arrow = MakeArrow();
        Destroy(arrow.gameObject, 2f);
        Debug.Log("Arrow destroyed");
        yield return null;
        //anim.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.3f);
        if(state != State.Interact)
        {
            state = State.Normal;
        }
    }

    private Projectiles MakeArrow()
    {
        Vector2 temp = new Vector2(anim.GetFloat("Horizontal"),anim.GetFloat("Vertical"));
        Projectiles arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectiles>();
        arrow.SetUp(temp, ChooseArrowDirection());
        return arrow;
    }

    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(anim.GetFloat("Vertical"), anim.GetFloat("Horizontal")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    private void HandleDodgeRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            int moddedN = 100 - (staminaModifier*25);
            Debug.Log(moddedN);
            if(curStam-(100-(staminaModifier*25)) > 0)
            {
                uim.UpdateSliderUI("Stamina", -(100-staminaModifier*25));
                curStam -= (100 - staminaModifier*25);
                state = State.DodgeRollSliding;
                slideDir = (newSpot - transform.position).normalized;
                slideSpeed = 40f;
            }
            else
            {
                FailedRoll();
            }
        }
    }

    private void FailedRoll()
    {
        Debug.Log("Roll failed.");
    }

    private void HandleDodgeRollSliding()
    {
        /*if(slideDir == new Vector3(1.0f, 0.0f, 0.0f))
        {
            anim.SetBool("RollRight", true);
        }
        */
        transform.position += slideDir * slideSpeed * Time.deltaTime;
        slideSpeed -= slideSpeed * 9f * Time.deltaTime;
        if(slideSpeed < 5f)
        {
            state = State.Normal;
            anim.SetBool("RollRight", false);
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Taking damage");
    }
}
