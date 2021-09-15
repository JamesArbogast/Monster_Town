using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public bool dialogueActive;
    public GameObject dialogueBox;

    public Queue<string> sentences;
    private PlayerActions player;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        player = GameObject.Find("Player").GetComponent<PlayerActions>();
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueActive)
        {
            dialogueBox.SetActive(true);
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        Debug.Log("ButtonClicked");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation.");
        player.isTalking = false;
        dialogueActive = false;
        sentences.Clear();
    }
}
