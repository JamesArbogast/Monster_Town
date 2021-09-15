using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{

    public Canvas confirmationCanvas;
    public GameStateMachine gameStateMachine;
    public CharacterUIInfo characterUIInfo;

    // Start is called before the first frame update
    void Start()
    {
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
        gameStateMachine.selectedPlayer = GameObject.Find("Hunter").GetComponent<HunterMale>();
        confirmationCanvas.enabled = true;
        characterUIInfo.showConfirmationScreen = true;
    }

    public void SelectPolitician()
    {
        Debug.Log("Politician Selected");
        gameStateMachine.selectedPlayer = GameObject.Find("Politician").GetComponent<PoliticianMale>();
        confirmationCanvas.enabled = true;
        characterUIInfo.showConfirmationScreen = true;
    }
    public void SelectScientist()
    {
        Debug.Log("Scientist Selected");
        gameStateMachine.selectedPlayer = GameObject.Find("Scientist").GetComponent<ScientistMale>();
        confirmationCanvas.enabled = true;
        characterUIInfo.showConfirmationScreen = true;
    }

    public void SelectCivilian()
    {
        Debug.Log("Civilian Selected");
        gameStateMachine.selectedPlayer = GameObject.Find("Civilian").GetComponent<CivilianMale>();
        confirmationCanvas.enabled = true;
        characterUIInfo.showConfirmationScreen = true;
    }
}
