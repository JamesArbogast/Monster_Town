using UnityEngine;
using System.Collections.Generic;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> collectiblePrefabs;

    public void SpawnCollectible(Vector2 position)
    {
        int index = Random.Range(0, collectiblePrefabs.Count);
        var selectedCollectible = collectiblePrefabs;
    }
}
