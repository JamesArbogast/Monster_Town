using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public CharacterController pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<CharacterController>();
        healthSlider.maxValue = pm.maxStam;
        healthSlider.value = pm.maxStam;
    }

    public void AddHealth(int healthNum)
    {
        if ((healthSlider.value += healthNum) > healthSlider.maxValue)
        {
            healthSlider.value = healthSlider.maxValue;
        }
        else
        {
            healthSlider.value += healthNum;
        }
    }

    public void DecreaseHealth(int healthNum)
    {

        if ((healthSlider.value -= healthNum) < healthSlider.minValue)
        {
            healthSlider.value = healthSlider.minValue;
        }
        else
        {
            healthSlider.value -= healthNum;
        }
    }
}
