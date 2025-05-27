using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField]
    private float playerAwarenessDistance;
    [SerializeField]
    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<CharacterController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        Debug.Log(enemyToPlayerVector);
        if (enemyToPlayerVector.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
            Debug.Log("Aware of player!");
        }
        else
        {
            AwareOfPlayer = false;
            Debug.Log("Not aware of player!");
        }
    }
}
