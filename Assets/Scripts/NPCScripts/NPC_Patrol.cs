using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class NPC_Patrol : MonoBehaviour
{
    [SerializeField]
    public Vector2[] patrolPoints;
    public float speed;
    public float pauseDuration = 1.5f;

    private bool isPaused = false;
    public Vector2 target;
    private int currentPatrolIndex;
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(SetPatrolPoint());
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        Vector2 direction = ((Vector3)target - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if(Vector2.Distance(transform.position, target) < .1f)
        {
            StartCoroutine(SetPatrolPoint());
        }
    }

    IEnumerator SetPatrolPoint()
    {
        isPaused = true;
        anim.Play("Idle");
        yield return new WaitForSeconds(pauseDuration);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        target = patrolPoints[currentPatrolIndex];
        isPaused = false;
        anim.Play("Walk");
    }
}
