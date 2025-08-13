using System.Collections;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public class DialogueCircle : MonoBehaviour
{
    public GameObject dialogueCircle;
    [SerializeField]
    // NPC States
    // these are all the states the NPC can be in while alive
    // NPC starts in an Idle state by default -- later, code will read NPC's profession/personality to determine other states
    public bool isIdle = true;
    public bool isAlerted,
                isPanicked,
                isBusy,
                isAttacking,
                isConvinced,
                isRecruited = false;
    [SerializeField]
    // Text Objects + Control
    public TextMeshProUGUI greet,
                       alert,
                       convince,
                       defend;
    public Canvas canvas;
    public GameObject canvasControl;

    [SerializeField] 
    // Interactions with player
    public bool npcGreeting = false;
    public bool npcAlerting = false;
    public bool npcDefending = false;
    public bool npcConvincing = false;
    public bool isGreeting = false;
    public bool isAlerting = false;
    public bool isDefending = false;
    public bool isConvincing = false;






    void Awake()
    {
        dialogueCircle.SetActive(false);
        canvasControl.SetActive(false);
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
                isGreeting = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && isGreeting)
                {
                    Debug.Log("should be greeting now...");
                    Greet();
                }
                if (Input.GetKeyUp(KeyCode.RightControl) && !npcGreeting)
                {
                    greet.text = "Greet";
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
                isAlerting = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && isAlerting)
                {
                    Debug.Log("should be alerting now...");
                    Alert();
                }
                if (Input.GetKeyUp(KeyCode.RightControl) && !npcAlerting)
                {
                    alert.text = "Alert";
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
                isDefending = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && isDefending)
                {
                    Debug.Log("should be defending now...");
                    Defend();
                }
                if (Input.GetKeyUp(KeyCode.RightControl) && !npcDefending)
                {
                    alert.text = "Defend";
                }
            }
            if (Input.GetKeyUp("[5]"))
            {
                defend.color = Color.blue;
                defend.fontStyle = FontStyles.Normal;
            }
            ////////////////////////////////////
            //////// Convince branch
            ///////////////////////////////////////
            if (Input.GetKey("[4]"))
            {
                convince.color = Color.white;
                convince.fontStyle = FontStyles.Bold;
                isConvincing = true;
                if (Input.GetKeyDown(KeyCode.RightControl) && isConvincing)
                {
                    Debug.Log("should be convincing now...");
                    Convince();
                }
                if (Input.GetKeyUp(KeyCode.RightControl) && !npcConvincing)
                {
                    alert.text = "Convince";
                }
            }
            if (Input.GetKeyUp("[4]"))
            {
                convince.color = Color.yellow;
                convince.fontStyle = FontStyles.Normal;
            }
        }
    }
    void Greet()
    {
        npcGreeting = true;
        isGreeting = false;
        greet.text = "Hey there!";
        alert.text = "";
        defend.text = "";
        convince.text = "";
        StartCoroutine(NPCSpeak());
    }
    void Alert()
    {
        npcAlerting = true;
        isAlerting = false;
        greet.text = "";
        alert.text = "AAHHHHH!";
        defend.text = "";
        convince.text = "";
        StartCoroutine(NPCSpeak());
    }
    void Defend()
    {
        npcDefending = true;
        isDefending = false;
        greet.text = "";
        alert.text = "";
        defend.text = "They won't know what hit 'em >:)";
        convince.text = "";
        StartCoroutine(NPCSpeak());
    }
    void Convince()
    {
        npcConvincing = true;
        isConvincing = false;
        greet.text = "";
        alert.text = "";
        defend.text = "";
        convince.text = "Oh shit! I believe you!";
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
    }    

    private IEnumerator NPCSpeak()
    {
        yield return new WaitForSeconds(3);
        ResetDialogueWheel();
    }
}
