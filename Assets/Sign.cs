using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject dialogueBox;
    public DialogueManager dialogueManager;
    public Text dialogueText;
    public string dialogue;
    public bool playerInRange;


    private void Awake()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        //dialogueText = dialogueBox.GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            dialogueManager.SetDialogueBoxActive();
            //Debug.Log(dialogueBox.activeInHierarchy);
            /*
            if(dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                Debug.Log("Setting dialogue box active.");
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
            }
            */
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
