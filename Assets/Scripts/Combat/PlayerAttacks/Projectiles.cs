using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public Vector3 rotation;
    public Rigidbody2D myRb;
    private Camera _camera;
    private Vector3 mousePos;

    // Start is called before the first frame update
    private void Awake()
    {
        _camera = Camera.main;
        mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
        rotation = transform.position - mousePos;
    }

    private void Start()
    {
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(10);
            Destroy(gameObject);
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
