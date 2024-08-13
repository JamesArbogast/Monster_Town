using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StamManager : MonoBehaviour
{
    public Slider stamSlider;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        stamSlider.maxValue = pm.maxEng;
        stamSlider.value = pm.maxEng;
    }

    public void AddEng()
    {
        stamSlider.value += 2;
        if (stamSlider.value > stamSlider.maxValue)
        {
            stamSlider.value = stamSlider.maxValue;
        }
    }

    public void DecreaseEng()
    {
        stamSlider.value -= 2;
        if (stamSlider.value < stamSlider.minValue)
        {
            stamSlider.value = stamSlider.minValue;
        }
    }
}
