using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Image []hearts;
    [SerializeField] UnityEvent onPlayerDeath;

    private void Start()
    {
        playerHealth.onHealthChange += UpdateUI;
    }
    private void UpdateUI()
    {
        Destroy(hearts[playerHealth.getPlayerHealth()].gameObject);

        if (playerHealth.getPlayerHealth() < 1)
            StartCoroutine(playerDeath());
    }

    IEnumerator playerDeath()
    {
        yield return new WaitForSeconds(1f);
        onPlayerDeath.Invoke();
    }


}
