using System.Collections;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class NPC_Interaction : MonoBehaviour
{
    // NPC starts in an Idle state by default -- later, code will read NPC's profession/personality to determine other states
    [SerializeField]
    public string npcName = "";
    public string profession = "";
    public int attack,
               defense,
               stubbornness,
               workEthic;
    public bool isConvinced = false;
    // These are locations NPC uses to navigate depending on Player input
    [SerializeField]
    public GameObject home = null;
    public GameObject business = null;
    public GameObject baseLocation = null;
    public GameObject requestWaypoint = null;
    // Player, Dialogue, Movement scripts + relevant components
    public CharacterController characterLogic = null;
    public DialogueCircle circleLogic = null;
    public NPC_Patrol movementLogic = null;
    public Rigidbody2D playerRb = null;
    public GameObject sprite;
    public bool isRolling = false;
    void Start()
    {
        npcName = gameObject.name;
        Debug.Log(npcName.ToString() + " is online");
        GameObject tempObj = GameObject.Find("TestPlayer");
        Debug.Log("tempObj is " + tempObj.name);
        // Player Object
        characterLogic = tempObj.GetComponent<CharacterController>();
        // Player's Rigidbody 2D
        playerRb = characterLogic.rgdbdy2D;
        // Dialogue
        circleLogic = GetComponent<DialogueCircle>();
        // Movement
        movementLogic = GetComponent<NPC_Patrol>();
    }

    // Update is called once per frame
    void Update()
    {
        // DEFEND INTERACTION
        //Debug.Log("Bertha's Position: " + transform.position + ", " + "Bertha's House: " + home.transform.position);
        if (circleLogic.npcDefending)
        {
            movementLogic.target = new Vector2(home.transform.position.x, home.transform.position.y);
            Debug.Log(npcName + " is heading home to defend...");
            if (transform.position.x - home.transform.position.x < 1)
            {
                sprite.SetActive(false);
                Debug.Log("Sprite should have disappeared now");
            }
        }
        // ALERT INTERACTION
        if (circleLogic.npcAlerting)
        {
            movementLogic.speed = 10;
        }
        // CONVINCE INTERACTION
        if (circleLogic.npcConvincing)
        {
            if (!isRolling)
            {
                int convinceAttempt = Random.Range(0, 10);
                circleLogic.npcConvincing = false;
                isRolling = true;
                Debug.Log("the player rolls: " + convinceAttempt + ", the NPC's stubbornness is: " + stubbornness);
                // SUCCESS STATE
                if (convinceAttempt >= stubbornness && isRolling)
                {
                    isConvinced=true;
                    Debug.Log(isConvinced);
                    isRolling=false;
                    Debug.Log("Success! NPC is convinced!");
                    return;
                }
                // FAIL STATE
                if (convinceAttempt < stubbornness && isRolling)
                {
                    isConvinced = false;
                    isRolling=false;
                    Debug.Log("Player failed to convince NPC");
                    return;
                }
            }
        }
    }
}

