using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> allUI = new List<GameObject>();
    public Dictionary<string, Slider> sliders = new Dictionary<string, Slider>();
    public PlayerMovement pm;
    public Coroutine regen;

    // Start is called before the first frame update
    void Start()
    {
        allUI = SortUI();
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<GameObject> SortUI()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Slider")
            {
                string type = child.gameObject.name.Replace("BarSlider", "");
                sliders.Add(type, child.gameObject.GetComponent<Slider>());
            }
            allUI.Add(child.gameObject);
        }
        return allUI;

    }

    public void UpdateSliderUI(string type, int num)
    {
        float fixNum = ((float)num / pm.maxStam);
        Slider curSlider = sliders[type];
        float newVal = fixNum + curSlider.value;
        curSlider.value = newVal;
        if (curSlider.value < curSlider.minValue)
        {
            curSlider.value = curSlider.minValue;
        }

        if (curSlider.value > curSlider.maxValue)
        {
            curSlider.value = curSlider.maxValue;
        }



        if (type == "Stamina")
        {
            if (regen != null)
            {
                StopCoroutine(regen);
            }
            Debug.Log("Starting refresh");
            regen = StartCoroutine(RegenStamina(type));
        }
    }

    public IEnumerator RegenStamina(string type)
    {
        yield return new WaitForSeconds(1);
        Slider curSlider = sliders[type];

        while (pm.curStam < pm.maxStam)
        {
            curSlider.value += curSlider.maxValue / (100f / pm.staminaModifier) * Time.deltaTime;
            pm.curStam += pm.maxStam / 20f * Time.deltaTime;
            yield return null;
        }
    }

}
