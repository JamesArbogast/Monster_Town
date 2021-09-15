using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorManagement : MonoBehaviour
{
    public GameObject hunterSprite;
    public GameObject politicianSprite;
    public GameObject scientistSprite;
    public GameObject civilianSprite;

    private Vector3 characterPosition;
    private Vector3 offScreen;

    private void Awake()
    {
        characterPosition = hunterSprite.transform.position;
        offScreen = scientistSprite.transform.position;
    }

    public void NextCharacterButton()
    {

    }

    public void PreviousCharacterButton()
    {

    }

}
