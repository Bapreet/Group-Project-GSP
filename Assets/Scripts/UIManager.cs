using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text playerHealthText;
    public TMP_Text attemptsText;
    public TMP_Text instructionText;

    public TMP_Text enemy1Text;
    public TMP_Text enemy2Text;
    public TMP_Text enemy3Text;

    public void UpdatePlayerHealth(int health)
    {
        if (playerHealthText != null)
            playerHealthText.text = "Health: " + (health * 25) + "%";
    }

    public void UpdateAttempts(int attempts)
    {
        if (attemptsText != null)
            attemptsText.text = "Attempts: " + attempts;
    }

    public void UpdateInstruction(string message)
    {
        if (instructionText != null)
            instructionText.text = message;
    }

    public void UpdateEnemyHealth(int enemyIndex, int health)
    {
        string value = "Enemy " + enemyIndex + ": " + (health * 25) + "%";

        if (enemyIndex == 1 && enemy1Text != null)
            enemy1Text.text = value;

        if (enemyIndex == 2 && enemy2Text != null)
            enemy2Text.text = value;

        if (enemyIndex == 3 && enemy3Text != null)
            enemy3Text.text = value;
    }
}