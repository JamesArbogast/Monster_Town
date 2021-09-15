using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScientistMale : BasePlayer
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
        playerName = "Prof. J. Vorthenstein";
        types = Types.SCIENTIST;

        //initial stats
        attack = 3;
        innovation = 4;
        charisma = 1;
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
