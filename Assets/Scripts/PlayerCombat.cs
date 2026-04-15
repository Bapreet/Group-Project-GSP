using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth = 4;
    public static int attempts = 0;

    public UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;
        
        if (uiManager != null)
        {
            uiManager.UpdatePlayerHealth(currentHealth);
            uiManager.UpdateAttempts(attempts);
            uiManager.UpdateInstruction("Find the key");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        if (uiManager != null)
            uiManager.UpdatePlayerHealth(currentHealth);

        if (currentHealth <= 0)
        {
            attempts++;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}