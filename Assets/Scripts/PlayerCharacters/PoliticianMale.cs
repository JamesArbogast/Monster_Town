﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliticianMale : BasePlayer
{
    public bool playerExists;
    public Scene currentScene;

    private void Awake()
    {
        playerExists = GameObject.Find("Player");
        currentScene = SceneManager.GetActiveScene();

        if (playerExists && currentScene.name != "CharacterSelect")
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        //initial info
        playerName = "Councilman Stafford";
        types = Types.POLITICIAN;

        //initial stats
        attack = 1;
        innovation = 3;
        charisma = 4;
        patience = 2;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
