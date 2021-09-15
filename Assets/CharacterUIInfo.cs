using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIInfo : MonoBehaviour
{
    //characters
    public GameObject hunter;
    public GameObject politician;
    public GameObject scientist;
    public GameObject civilian;

    public Text hunterNameTextUI;
    public Text politicianNameTextUI;
    public Text scientistNameTextUI;
    public Text civilianNameTextUI;

    public bool showConfirmationScreen;
    public Text confirmationScreenText;
    public GameStateMachine gameStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        gameStateMachine = GameObject.Find("GameStateMachine").GetComponent<GameStateMachine>();
        hunterNameTextUI.text = hunter.GetComponent<HunterMale>().playerName;
        politicianNameTextUI.text = politician.GetComponent<PoliticianMale>().playerName;
        scientistNameTextUI.text = scientist.GetComponent<ScientistMale>().playerName;
        civilianNameTextUI.text = civilian.GetComponent<CivilianMale>().playerName;
    }

    // Update is called once per frame
    void Update()
    {
        if(showConfirmationScreen == true)
        {
            confirmationScreenText.text = "You have chosen to experience your next three days as " + gameStateMachine.selectedPlayer.playerName + " the " + gameStateMachine.selectedPlayer.types + ". Do you wish to continue?";
        }
    }
}
