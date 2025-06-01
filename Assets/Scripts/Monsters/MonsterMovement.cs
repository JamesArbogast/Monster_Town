using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    public float rotationSpeed;
    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    private float changeDirectionCD;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        targetDirection = transform.up;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }


    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }
    private void HandleRandomDirectionChange()
    {
        changeDirectionCD -= Time.deltaTime;
        if (changeDirectionCD <=0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCD = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
    }    

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        _rigidbody.linearVelocity = transform.up * speed;
    }
}
