using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public Slider energySlider;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        energySlider.maxValue = pm.maxEng;
        energySlider.value = pm.maxEng;
    }

    public void AddEng()
    {
        energySlider.value += 2;
        if(energySlider.value > energySlider.maxValue)
        {
            energySlider.value = energySlider.maxValue;
        }
    }

    public void DecreaseEng()
    {
        energySlider.value -= 2;
        if (energySlider.value < energySlider.minValue)
        {
            energySlider.value = energySlider.minValue;
        }
    }
}
