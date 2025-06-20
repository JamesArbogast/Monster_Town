using UnityEngine;

public class MonsterDestroyController : MonoBehaviour
{
    public void DestroyMonster(float delay)
    {
        Destroy(gameObject, delay);
    }
}
