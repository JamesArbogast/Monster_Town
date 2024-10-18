using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public Slider stamSlider;
    public PlayerMovement pm;
    public float currentStamina;
    public bool succesfullRoll = false;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    // Singleton. Disable if you don't want this carrying over between scenes
    public static StaminaManager instance;
    //

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        stamSlider = gameObject.GetComponent<Slider>(); ;
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        stamSlider.maxValue = pm.maxEng;
        currentStamina = pm.maxEng;
        stamSlider.value = currentStamina;
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

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            succesfullRoll = true;
            currentStamina -= amount;
            stamSlider.value = currentStamina;
        }
        else
        {
            Debug.Log("Not enough stamina");
        }
    }

    public IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);

        while(currentStamina < pm.maxEng)
        {
            currentStamina += pm.maxEng / 100;
            stamSlider.value = currentStamina;
            yield return regenTick;
        }
    }

    //Add to max stamina

    //Increase regen of stamina

    //Add threshhold???

    //Lowering of ma

}
