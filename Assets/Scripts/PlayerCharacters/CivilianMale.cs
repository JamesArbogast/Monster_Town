using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CivilianMale : BasePlayer
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
        playerName = "George";
        types = Types.CIVILIAN;

        //initial stats
        attack = 2;
        innovation = 2;
        charisma = 2;
        patience = 4;
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
