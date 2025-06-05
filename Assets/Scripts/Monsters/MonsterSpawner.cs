using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minimumSpawnTime;

    [SerializeField]
    private float maximumSpawnTime;

    [SerializeField]
    private float timeUntilSpawn;



    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <=0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntiilSpawn();
        }
    }

    private void SetTimeUntiilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
