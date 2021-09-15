using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HunterMale : BasePlayer
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
        playerName = "Azerius";
        types = Types.HUNTER;

        //initial stats
        attack = 4;
        innovation = 1;
        charisma = 3;
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
