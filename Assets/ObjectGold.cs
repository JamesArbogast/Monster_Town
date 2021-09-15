using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGold : MonoBehaviour
{

    public int objectGold;
    public Gold playerGold;
    public bool brokenOpen;

    // Start is called before the first frame update
    void Start()
    {
        playerGold = GameObject.Find("Player").GetComponent<Gold>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            if(brokenOpen == true)
            {
                playerGold.objectGold = objectGold;
                Debug.Log("Player can collect money");
            }
        }
    }

}
