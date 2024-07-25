using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        healthSlider.maxValue = pm.maxStam;
        healthSlider.value = pm.maxStam;
    }

    public void AddStam()
    {
        healthSlider.value += 2;
        if (healthSlider.value > healthSlider.maxValue)
        {
            healthSlider.value = healthSlider.maxValue;
        }
    }

    public void DecreaseStam()
    {
        healthSlider.value -= 2;
        if (healthSlider.value < healthSlider.minValue)
        {
            healthSlider.value = healthSlider.minValue;
        }
    }
}
