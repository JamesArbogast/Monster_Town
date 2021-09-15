using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    public bool gameStateMachineExists;
    public Scene currentScene;
    public BasePlayer selectedPlayer;

    private void Awake()
    {
        gameStateMachineExists = GameObject.Find("GameStateMachine");
        currentScene = SceneManager.GetActiveScene();

        if (gameStateMachineExists && currentScene.name != "CharacterSelect")
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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
