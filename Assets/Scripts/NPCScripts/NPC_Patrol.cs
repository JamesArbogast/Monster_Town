using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector2[] patrolPoints;
    public float speed = 2;
    public float pauseDuration = 1.5f;

    private bool isPaused=false;
    private Vector2 target;
    private int currentPatrolIndex;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        target = patrolPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = ((Vector3)target - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if(Vector2.Distance(transform.position, target) < .1)
        {
            SetPatrolPoint();
        }
    }

    private void SetPatrolPoint()
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        target = patrolPoints[currentPatrolIndex];
    }
}
