using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        Debug.Log("Boss died!");
        Destroy(gameObject);
        SceneManager.LoadScene("WinScene");
        
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
