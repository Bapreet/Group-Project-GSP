using UnityEngine;

public class Room2Entrance : MonoBehaviour
{
    public GameObject backDoorBlock;
    public CreatureEnemy[] enemies;
    public UIManager uiManager;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            foreach (CreatureEnemy enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.ActivateEnemy();
                }
            }

            if (uiManager != null)
            {
                uiManager.UpdateInstruction("Press G to shoot");
            }

            Invoke(nameof(CloseBackDoor), 0.5f);
        }
    }

    void CloseBackDoor()
    {
        if (backDoorBlock != null)
        {
            backDoorBlock.SetActive(true);
        }
    }
}