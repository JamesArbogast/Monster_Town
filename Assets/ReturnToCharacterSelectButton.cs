using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToCharacterSelectButton : MonoBehaviour
{

    public Canvas characterConfirmationCanvas;
    public CharacterUIInfo characterUIInfo;

    // Start is called before the first frame update
    void Start()
    {
        characterConfirmationCanvas = GameObject.Find("ConfirmationCanvas").GetComponent<Canvas>();
        characterUIInfo = GameObject.Find("CharacterSelectCanvas").GetComponent<CharacterUIInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToCharacterSelectScreen()
    {
        characterConfirmationCanvas.enabled = false;
        characterUIInfo.showConfirmationScreen = false;
    }
}
