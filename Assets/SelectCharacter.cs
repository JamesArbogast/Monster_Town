using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{

    public Canvas confirmationCanvas;
    public GameStateMachine gameStateMachine;
    public CharacterUIInfo characterUIInfo;
    public Text characterName;
    public Text characterType;
    public Text characterPerk;
    public BasePlayer hunter;
    public BasePlayer politician;
    public BasePlayer scientist;
    public BasePlayer civilian;

    // Start is called before the first frame update
    void Start()
    {
        //finding character game objects

        //ui config
        characterUIInfo = GameObject.Find("CharacterSelectCanvas").GetComponent<CharacterUIInfo>();
        confirmationCanvas = GameObject.Find("ConfirmationCanvas").GetComponent<Canvas>();
        confirmationCanvas.enabled = false;
        gameStateMachine = GameObject.Find("GameStateMachine").GetComponent<GameStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectHunter()
    {
        Debug.Log("Hunter Selected");
        confirmationCanvas.enabled = true;
        characterUIInfo.showConfirmationScreen = true;
        gameStateMachine.selectedPlayer = hunter;
    }

    public void SelectPolitician()
    {
        Debug.Log("Politician Selected");
        characterUIInfo.showConfirmationScreen = true;
        confirmationCanvas.enabled = true;
        gameStateMachine.selectedPlayer = politician;
    }
    public void SelectScientist()
    {
        Debug.Log("Scientist Selected");
        characterUIInfo.showConfirmationScreen = true;
        confirmationCanvas.enabled = true;
        gameStateMachine.selectedPlayer = scientist;
    }

    public void SelectCivilian()
    {
        Debug.Log("Civilian Selected");
        gameStateMachine.selectedPlayer = civilian;
        confirmationCanvas.enabled = true;
        characterUIInfo.showConfirmationScreen = true;
    }
}
