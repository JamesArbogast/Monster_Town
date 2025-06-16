using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    public float rotationSpeed;
    [SerializeField]
    private float screenBorder;
    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    private float changeDirectionCD;
    private Camera _camera;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        targetDirection = transform.up;
        _camera = Camera.main;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        //RotateTowardsTarget();
        SetVelocity();
    }


    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        HandleEnemyOffScreen();
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

    private void HandleEnemyOffScreen()
    {
        Vector2 screenPos = _camera.WorldToScreenPoint(transform.position);
        //Debug.Log(screenPos.x + ", " + screenPos.y);
        if ((screenPos.x < screenBorder && targetDirection.x < 0) ||
            (screenPos.x > _camera.pixelWidth - screenBorder && targetDirection.x > 0))
        {
            targetDirection = new Vector2(-targetDirection.x, targetDirection.y);
        }

        if ((screenPos.y < screenBorder && targetDirection.y < 0) ||
            (screenPos.y > _camera.pixelHeight - screenBorder && targetDirection.y > 0))
        {
            targetDirection = new Vector2(targetDirection.x, -targetDirection.y);
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
        _rigidbody.linearVelocity = targetDirection * speed;
    }
}
