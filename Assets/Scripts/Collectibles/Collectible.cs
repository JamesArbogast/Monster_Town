using UnityEngine;

public class Collectible : MonoBehaviour
{
    private ICollectibleBehaviour collectibleBehaviour;

    private void Awake()
    {
        collectibleBehaviour = GetComponent<ICollectibleBehaviour>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        var player = collision.GetComponent<CharacterController>();

        if(player != null)
        {
            collectibleBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
