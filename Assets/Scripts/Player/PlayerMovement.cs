using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : BasePlayer
{
    [SerializeField]
    private float speed;
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    public Vector2 movement;
    public Vector2 movementInput;
    public Animator anim;

    //extra movements
    private Vector3 slideDir;
    private Vector3 newSpot;
    public float slideSpeed;
    private State state;

    //UI manager
    public UIManager uim;
    public StaminaManager sm;


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

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    /*
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
        if(Input.GetKeyDown("Space"))
        {
            Debug.Log("Projectile triggered.");
            StartCoroutine(ProjectileAttack());
        }

    }
    */

    private void FixedUpdate()
    {
        //Movement
        rigidBody.linearVelocity = movementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
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
            sm.UseStamina(25);
            if (sm.succesfullRoll)
            {
                sm.succesfullRoll = false;
                HandleDodgeRollSliding();
                Debug.Log("Roll completed.");
                StartCoroutine(sm.RegenStamina());
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

    public void HandleDodgeRollSliding()
    {
        //if(slideDir == new Vector3(1.0f, 0.0f, 0.0f))
        //{
        //    anim.SetBool("RollRight", true);
        //}

        Debug.Log("Rollin");
        transform.position += slideDir * slideSpeed * Time.deltaTime;
        slideSpeed -= slideSpeed * 9f * Time.deltaTime;
        //print(slideSpeed);
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
