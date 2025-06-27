using UnityEngine;

public class MonsterScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int killScore;

    private ScoreController scoreController;

    private void Awake()
    {
        scoreController = FindFirstObjectByType<ScoreController>();
    }

    public void AllocateScore()
    {
        scoreController.AddScore(killScore);
    }
}
