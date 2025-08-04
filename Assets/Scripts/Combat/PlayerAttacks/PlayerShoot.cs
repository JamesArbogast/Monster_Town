using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private Transform gunOffset;

    [SerializeField]
    private float projectileRotationOffset;

    [SerializeField]
    private float timeBetweenShots;

    //Shot UI
    [SerializeField]
    private Image shotBarFillImage;

    //Shot accuracy
    [SerializeField]
    private Slider shotSlider;
    [SerializeField]
    private float shotSliderMin;
    [SerializeField]
    private float shotSliderMax;
    [SerializeField]
    private float shotSliderTime;
    [SerializeField]
    private float shotDepletionSliderTime;
    [SerializeField]
    private bool firing;
    [SerializeField]
    private bool fireContinuously;
    [SerializeField]
    private bool fireSingle;
    private float lastFireTime;

    private Coroutine fillCoroutine;

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
        StartFillBar();
        //fireContinuously = inputValue.isPressed;
        if(firing)
        {
            fireSingle = true;
        }
    }

    private void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, gunOffset.position, transform.rotation);
        Projectiles firedProjectile = projectile.GetComponent<Projectiles>();
        float rot = Mathf.Atan2(firedProjectile.rotation.y, firedProjectile.rotation.x) * Mathf.Rad2Deg;
        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        rigidBody.linearVelocity = new Vector2(firedProjectile.direction.x, firedProjectile.direction.y).normalized * projectileSpeed;
        firedProjectile.transform.rotation = Quaternion.Euler(0, 0, rot+90);
    }

    //Call this method to start filling the shot bar
    public bool StartFillBar()
    {
        /*
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine); // Stop any existing fill operations
            firing = false;
            return firing;
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            print("Pressed");
            // Fills to 100%
            StartCoroutine(FillBarOverTime(1.0f));
            firing = false;
            return firing;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //once you let go of left click, stop filling bar
            StopCoroutine(FillBarOverTime(1.0f));
            //set fire to true
            firing = true;
            //start depleting fill bar
            StartCoroutine(ReverseFillBarOverTime(0f));
            return firing;
        }
        else
        {
            firing = false;
            return firing;
        }
    }

    private IEnumerator FillBarOverTime(float targetFillAmount)
    {
        float startFillAmount = shotBarFillImage.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < shotSliderTime)
        {
            elapsedTime += Time.deltaTime;
            float currentFillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / shotSliderTime);
            shotBarFillImage.fillAmount = currentFillAmount;
            yield return null; // Wait for the next frame
        }
        shotBarFillImage.fillAmount = targetFillAmount; // Ensure final value is accurate
    }

    private IEnumerator ReverseFillBarOverTime(float targetFillAmount)
    {
        float startFillAmount = shotBarFillImage.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < shotDepletionSliderTime)
        {
            elapsedTime += Time.deltaTime;
            float currentFillAmount = Mathf.Lerp(targetFillAmount, startFillAmount, shotDepletionSliderTime / elapsedTime);
            Debug.Log(currentFillAmount);
            shotBarFillImage.fillAmount = currentFillAmount;
            yield return null; //  Wait for the next frame
        }
        shotBarFillImage.fillAmount = targetFillAmount; // Ensure final value is accurate
    }
}
