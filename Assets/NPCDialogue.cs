using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public bool playerWithinRange;
    private bool convoPossible;
    public bool convoStarted;
    public bool dialogueActive;
    public BoxCollider2D npcCollider;
    public GameObject dialogueBox;
    public DialogueManager dialogueManager;
    public PlayerActions playerActions;
    public DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        npcCollider = FindObjectOfType<BoxCollider2D>();
        playerActions = GameObject.Find("Player").GetComponent<PlayerActions>();
        dialogueTrigger = GetComponentInChildren<DialogueTrigger>(); //GameObject.Find("DialogueTrigger").GetComponent<DialogueTrigger>();
        dialogueBox = GameObject.Find("DialogueBox");
        //dialogueBox.SetActive(false);
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Player Within Range");
        playerWithinRange = true;
        convoPossible = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Player Out of Range");
        playerWithinRange = false;
        convoPossible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (convoPossible == true)
        {
            TriggerNPCDialogue();
        }
        else
        {
            dialogueManager.dialogueActive = false;
        }
    }

    public void TriggerNPCDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Dialogue Active");
            playerActions.isTalking = true;
            dialogueManager.dialogueActive = true;
            dialogueTrigger.TriggerDialogue();
            convoPossible = true;
        }

    }
}
