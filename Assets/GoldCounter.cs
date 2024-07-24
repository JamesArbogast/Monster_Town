using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{

    BasePlayer plyr;
    public TMP_Text gold;

    // Start is called before the first frame update
    void Start()
    {
        plyr = GameObject.Find("Player").GetComponent<BasePlayer>();
        gold = GetComponent<TextMeshProUGUI>();
        gold.text = "Gold:" + plyr.gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
