using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;

    private void Update()
    {
        if(maxHealth <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeDamage(int dmg)
    {
        maxHealth -= dmg;
        healthBar.fillAmount -= dmg / 100f;
    }
}
