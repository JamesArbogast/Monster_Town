using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator anim;

    private int lvlToLoad;

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeToLevel(int lvlIndex)
    {
        lvlToLoad = lvlIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(lvlToLoad);
    }
}
