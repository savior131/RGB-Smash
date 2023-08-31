using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Image []hearts;

    private void Start()
    {
        playerHealth.onHealthChange += UpdateUI;
    }
    private void UpdateUI()
    {
        Destroy(hearts[playerHealth.getPlayerHealth()].gameObject);
    }


}
