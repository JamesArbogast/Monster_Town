using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using TMPro;

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
    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    public float colorTransitionTime;

    //Shot accuracy and power
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
    private TMP_Text shotPowerPercentageText;

    //firing bools
    [SerializeField]
    private bool beginFiring;
    [SerializeField]
    private bool firing = false;
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
                Debug.Log("Firing projectile");
                FireProjectile();
                lastFireTime = Time.time;
                fireSingle = false;
            }
        }
    }


    private Color SetGaugeColor(float percentage)
    {
        Color color = new Color();
        return color;
    }

    private void ColorTransition()
    {
        targetPoint += Time.deltaTime/colorTransitionTime;
        shotBarFillImage.color = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);
        if(targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if (targetColorIndex == colors.Length)
                targetColorIndex = 0;
        }
    }

    private void OnFire(InputValue inputValue)
    {
        StartFillBar();
        //fireContinuously = inputValue.isPressed;
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
    public void StartFillBar()
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
            beginFiring = true;
            StartCoroutine(FillBarOverTime(1.0f));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            beginFiring = false;
            //once you let go of left click, stop filling bar
            firing = true;
            if (firing)
            {
                Debug.Log("Firing");
                fireSingle = true;
            }
            StopCoroutine(FillBarOverTime(0f));
            Debug.Log("Firing is true");
            //show percentage of bar reached for accuracy and power data to ui
            shotPowerPercentageText.text = Mathf.Round((shotBarFillImage.fillAmount * 100)).ToString() + "%";
            //set firing to true to release shot
            //start depleting fill bar
            StartCoroutine(ReverseFillBarOverTime(0f));
            //set firing to false 
        }
        else
        {
            firing = false;
        }
    }

    private IEnumerator FillBarOverTime(float targetFillAmount)
    {
        Debug.Log("Filling bar.");
        float startFillAmount = shotBarFillImage.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < shotSliderTime && beginFiring)
        {
            ColorTransition();
            elapsedTime += Time.deltaTime;
            float currentFillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / shotSliderTime);
            shotBarFillImage.fillAmount = currentFillAmount;
            yield return null; // Wait for the next frame
        }
        //shotBarFillImage.fillAmount = targetFillAmount; // Ensure final value is accurate
    }

    private IEnumerator ReverseFillBarOverTime(float targetFillAmount)
    {
        firing = false;
        float startFillAmount = shotBarFillImage.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < shotDepletionSliderTime)
        {
            elapsedTime += Time.deltaTime;
            float currentFillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / shotDepletionSliderTime);
            shotBarFillImage.fillAmount = currentFillAmount;
            yield return null; //  Wait for the next frame
        }
        //shotBarFillImage.fillAmount = targetFillAmount; // Ensure final value is accurate
    }
}
