using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        healthController.isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        healthController.isInvincible = false;
    }
}
