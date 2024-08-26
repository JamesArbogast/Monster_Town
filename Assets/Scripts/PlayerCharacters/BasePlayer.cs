using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePlayer : MonoBehaviour
{

    //base information
    public string playerName;
    public Sprite playerImage;

    public enum Types
    {
        HUNTER,
        SCIENTIST,
        POLITICIAN,
        CIVILIAN,
    }

    public Types types;

    //stats
    public int attack;
    public int innovation;
    public int charisma;
    public int patience;

    //stat modifiers
    public int staminaModifier;
    public int SpeedModifier;

    //unique traits and items
    public GameObject baseItem;
    public GameObject uniquePotentialItem;
    public GameObject uniqueBuilding;

    //inventory
    public int gold;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
