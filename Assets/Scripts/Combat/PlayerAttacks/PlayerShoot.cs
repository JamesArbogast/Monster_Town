using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private Transform gunOffset;

    [SerializeField]
    private float timeBetweenShots;

    private bool fireContinuously;
    private bool fireSingle;
    private float lastFireTime;

    // Update is called once per frame
    void Update()
    {
        if (fireContinuously || fireSingle)
        {
            float timeSinceLastFire = Time.time - lastFireTime;

            if (timeSinceLastFire >= timeBetweenShots)
            {
                FireProjectile();
                lastFireTime = Time.time;
                fireSingle = false;
            }


        }
    }

    private void OnFire(InputValue inputValue)
    {
        fireContinuously = inputValue.isPressed;

        if(inputValue.isPressed)
        {
            fireSingle = true;
        }
    }

    private void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, gunOffset.position, transform.rotation);
        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();

        rigidBody.linearVelocity = projectileSpeed * transform.up;
    }
}
