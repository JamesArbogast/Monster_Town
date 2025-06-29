using UnityEngine;

public class HealthCollectibleBehavior : MonoBehaviour, ICollectibleBehaviour
{
    [SerializeField]
    private float healthAmount;

    public void OnCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(healthAmount);
    }
}
