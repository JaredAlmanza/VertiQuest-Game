using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int GetCurrentHealth()
{
    return currentHealth;
}


    public int CurrentHealth => currentHealth; 

    void Start()
    {
        currentHealth = maxHealth;
    }

    [System.Obsolete]
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}

