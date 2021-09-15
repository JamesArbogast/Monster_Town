using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public Collider2D meleeBoxCollider;
    public PlayerActions playerActions;


    // Start is called before the first frame update
    void Start()
    {
        meleeBoxCollider = GetComponent<Collider2D>();
        playerActions = GameObject.Find("Player").GetComponent<PlayerActions>();
    }

    // Update is called once per frame
    void Update()
    {

        if(playerActions.moveInput == new Vector2(0,-1))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        if(playerActions.moveInput == new Vector2(0, 1))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, 1, 0);
        }
        if (playerActions.moveInput == new Vector2(-1, 0))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, -0.707106829f, 0.707106829f);
        }
        if (playerActions.moveInput == new Vector2(1, 0))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, 0.707106829f, 0.707106829f);
        }
        if (playerActions.moveInput == new Vector2(0, 0))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, 0.953716993f, 0.30070582f);
        }
        if (playerActions.moveInput == new Vector2(0.707106769f, 0.707106769f))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, 0.953716993f, 0.30070582f);
        }
        if (playerActions.moveInput == new Vector2(-0.707106769f, 0.707106769f))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, -0.953716934f, 0.30070582f);
        }
        if (playerActions.moveInput == new Vector2(0.707106769f, -0.707106769f))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, 0.382683426f, 0.923879564f);
        }
        if (playerActions.moveInput == new Vector2(-0.707106769f, -0.707106769f))
        {
            meleeBoxCollider.transform.rotation = new Quaternion(0, 0, -0.382683426f, 0.923879564f);
        }
    }
}
