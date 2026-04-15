using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel;
    private bool hasWon = false;

    void Update()
    {
        if (hasWon) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            hasWon = true;

            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}