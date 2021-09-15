using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{

    public int playerGold;
    public Text goldDisplay;
    public Collider2D playerCollider;
    public bool canCollectMoney;
    public int objectGold;

    // Start is called before the first frame update
    void Start()
    {
        goldDisplay = GameObject.Find("GoldTextDisplay").GetComponent<Text>();
        playerCollider = GameObject.Find("InteractionTrigger").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        goldDisplay.text = "GOLD: " + playerGold;
    }

    public void AccumulateGold(int gold)
    {
        playerGold += gold;
    }

    public void LoseGold(int gold)
    {
        playerGold -= gold;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "LootCrate")
        {
            AccumulateGold(objectGold);
        }
    }
}
