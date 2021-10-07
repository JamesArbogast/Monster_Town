using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SetUp(Vector2 velocity, Vector3 direction)
    {
        myRb.velocity = velocity.normalized * Time.deltaTime;
        transform.rotation = Quaternion.Euler(direction);
    }
}
