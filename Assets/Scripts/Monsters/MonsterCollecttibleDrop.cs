using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterCollecttibleDrop : MonoBehaviour
{
    [SerializeField]
    private float chanceOfCollectibleDrop;

    private CollectibleSpawner collectibleSpawner;

    private void Awake()
    {
        collectibleSpawner = FindFirstObjectByType<CollectibleSpawner>();
    }

    public void RandomlyDropCollectible()
    {
        float random = Random.Range(0f, 1f);
        if(chanceOfCollectibleDrop >= random)
        {
            Debug.Log("Dropping collectible");
            collectibleSpawner.SpawnCollectible(transform.position);
        }
    }
}
