using System.Collections;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DialogueCircle : MonoBehaviour
{
    public GameObject dialogueCircle;
    [SerializeField]
    // NPC States
    // these are all the states the NPC can be in while alive
    // NPC starts in an Idle state by default -- later, code will read NPC's profession/personality to determine other states
    public bool isIdle = true;
    //public bool isAlerted,
    //            isPanicked,
    //            isBusy,
    //            isAttacking,
    //            isConvinced,
    //            isRecruited = false;
    [SerializeField]
    // Text Objects + Control
    public TextMeshProUGUI greet,
                       alert,
                       convince,
                       defend;
    private Rigidbody2D playerRb;
    public NPC_Interaction npcInteraction = null;
    public CharacterController characterLogic = null;
    public NPC_Patrol movementLogic = null;
    public Canvas canvas;
    public GameObject canvasControl;
    // Interactions with player
    public bool npcGreeting,
                npcAlerting,
                npcDefending,
                npcConvincing,
                playerGreeting,
                playerAlerting,
                playerDefending,
                playerConvincing = false;


    void Awake()
    {
        dialogueCircle.SetActive(false);
        canvasControl.SetActive(false);
        GameObject tempObj = GameObject.Find("TestPlayer");
        npcInteraction = GetComponent<NPC_Interaction>();
        movementLogic = GetComponent<NPC_Patrol>();
        //Debug.Log("tempObj is " + tempObj.name);
        //characterLogic = tempObj.GetComponent<CharacterController>();
        ////playerRb = characterLogic.rgdbdy2D;
    }

    // Update is called once per frame
    void Update()
    {
        // monitor for player pressing E to see dialogue options
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueCircle.SetActive(true);
            canvasControl.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.E) && !npcGreeting && !npcAlerting && !npcDefending && !npcConvincing)
        {
            dialogueCircle.SetActive(false);
            canvasControl.SetActive(false);
        }
        if (dialogueCircle)
        {
            ////////////////////////////////////
            //////// Greet branch
            ///////////////////////////////////////
            if (Input.GetKey("[8]"))
            {
                greet.color = Color.white;
                greet.fontStyle = FontStyles.Bold;
                playerGreeting = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && playerGreeting)
                {
                    Debug.Log("should be greeting now...");
                    Greet();
                }
            }
            if (Input.GetKeyUp("[8]"))
            {
                greet.color = Color.green;
                greet.fontStyle = FontStyles.Normal;
            }
            ////////////////////////////////////
            ///////// Alert branch
            ///////////////////////////////////////
            if (Input.GetKey("[6]"))
            {
                alert.color = Color.white;
                alert.fontStyle = FontStyles.Bold;
                playerAlerting = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && playerAlerting)
                {
                    Debug.Log("should be alerting now...");
                    Alert();
                }
            }
            if (Input.GetKeyUp("[6]"))
            {
                alert.color = Color.red;
                alert.fontStyle = FontStyles.Normal;
            }
            ////////////////////////////////////
            //////// Defend branch
            ///////////////////////////////////////
            if (Input.GetKey("[5]"))
            {
                defend.color = Color.white;
                defend.fontStyle = FontStyles.Bold;
                playerDefending = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && playerDefending)
                {
                    Debug.Log("should be defending now...");
                    Defend();
                }
            }
            if (Input.GetKeyUp("[5]"))
            {
                defend.color = Color.lightBlue;
                defend.fontStyle = FontStyles.Normal;
            }

            ////////////////////////////////////
            //////// Convince branch
            ///////////////////////////////////////
            if (Input.GetKey("[4]"))
            {
                convince.color = Color.white;
                convince.fontStyle = FontStyles.Bold;
                playerConvincing = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && playerConvincing)
                {
                    Debug.Log("should be convincing now...");
                    Convince();
                }
            }
            if (Input.GetKeyUp("[4]"))
            {
                convince.color = Color.yellow;
                convince.fontStyle = FontStyles.Normal;
            }

            ////////////////////////////////////
            //////// NPC Listening
            ///////////////////////////////////////
            if (transform.position.x - npcInteraction.home.transform.position.x < 1)
            {
                StartCoroutine(NPCSpeak());
            }
        }
    }
    void Greet()
    {
        npcGreeting = true;
        playerGreeting = false;
        greet.text = "Hey there!";
        alert.text = "";
        defend.text = "";
        convince.text = "";
        StartCoroutine(NPCSpeak());
    }
    void Alert()
    {
        npcAlerting = true;
        playerAlerting = false;
        greet.text = "";
        alert.text = "AAHHHHH!";
        defend.text = "";
        convince.text = "";
        StartCoroutine(NPCSpeak());
    }
    void Defend()
    {
        npcDefending = true;
        playerDefending = false;
        greet.text = "";
        alert.text = "";
        defend.text = "They won't know what hit 'em >:)";
        convince.text = "";
        if (transform.position.x - npcInteraction.home.transform.position.x < 1)
        {
            StartCoroutine(NPCSpeak());
        }
    }
    void Convince()
    {
        npcConvincing = true;
        playerConvincing = false;
        greet.text = "";
        alert.text = "";
        defend.text = "";
        if(npcInteraction.isConvinced)
        {
            convince.text = "Oh shit! I believe you!";
        }
        if(npcInteraction.isConvinced == false)
        {
            convince.text = "Get the fuck outta heeeya!";
        }
        StartCoroutine(NPCSpeak());
    }
    void ResetDialogueWheel()
    {
        greet.text = "Greet";
        alert.text = "Alert";
        defend.text = "Defend";
        convince.text = "Convince";
        canvasControl.SetActive(false);
        dialogueCircle.SetActive(false);
        npcGreeting = false;
        npcAlerting = false;
        npcDefending = false;
        npcConvincing=false;
        npcInteraction.isConvinced = false;
    }    

    public IEnumerator NPCSpeak()
    {
        dialogueCircle.SetActive(false);
        yield return new WaitForSeconds(3);
        // RESET NPC SETTINGS
        npcInteraction.sprite.SetActive(true);
        movementLogic.speed = 2;
        ResetDialogueWheel();
    }
}
