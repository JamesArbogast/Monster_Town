using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRb;
    private Camera _camera;
    // Start is called before the first frame update
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    public void SetUp(Vector2 velocity, Vector3 direction)
    {
        myRb.linearVelocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPos = _camera.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 ||
            screenPos.x > _camera.pixelWidth ||
            screenPos.y < 0 ||
            screenPos.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
