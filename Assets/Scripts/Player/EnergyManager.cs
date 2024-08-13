using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngManager : MonoBehaviour
{
    public Slider energySlider;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        energySlider.maxValue = pm.maxEng;
        energySlider.value = pm.maxEng;
    }

    public void AddEng(int engNum)
    {
        if((energySlider.value += engNum) > energySlider.maxValue)
        {
            energySlider.value = energySlider.maxValue;
        }
        else
        {
            energySlider.value += engNum;
        }
    }

    public void DecreaseEng(int engNum)
    {
        if ((energySlider.value -= engNum) < energySlider.minValue)
        {
            energySlider.value = energySlider.minValue;
        }
        else
        {
            energySlider.value -= engNum;
        }
    }
}
