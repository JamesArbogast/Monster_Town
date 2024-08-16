using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> allUI = new List<GameObject>();
    public Dictionary<string, Slider> sliders = new Dictionary<string, Slider>();

    // Start is called before the first frame update
    void Start()
    {
        allUI = SortUI();
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

        UpdateSliderUI("Stamina", 35);
        return allUI;

    }

    void UpdateSliderUI(string type, int num)
    {
        Debug.Log(num);
        float fixNum = ((float)num / 100);
        Debug.Log(fixNum);
        Slider curSlider = sliders[type];
        float newVal = fixNum + curSlider.value;
        Debug.Log(newVal);
        curSlider.value = newVal;
        if (curSlider.value < curSlider.minValue)
        {
            curSlider.value = curSlider.minValue;
        }

        if (curSlider.value > curSlider.maxValue)
        {
            curSlider.value = curSlider.maxValue;
        }
        Debug.Log(curSlider.value);
    }

}
