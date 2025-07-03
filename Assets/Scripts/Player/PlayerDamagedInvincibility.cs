using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;

    [SerializeField]
    private Color flashColor;

    [SerializeField]
    private int numberOfFlashes;
    private InvincibilityController invincibilityController;

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();    
    }
    public void StartInvincibility()
    {
        invincibilityController.StartInvincibility(invincibilityDuration, flashColor, numberOfFlashes);
    }
}
