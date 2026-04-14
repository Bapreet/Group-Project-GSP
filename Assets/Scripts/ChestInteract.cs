using UnityEngine;
using TMPro;

public class ChestInteract : MonoBehaviour
{
    public GameObject openedChestVisual;
    public GameObject closedChestVisual;
    public TMP_Text messageText;

    private bool playerInRange = false;
    private bool opened = false;

    private void Start()
    {
        // Make sure chest starts closed
        if (closedChestVisual != null) closedChestVisual.SetActive(true);
        if (openedChestVisual != null) openedChestVisual.SetActive(false);

        if (messageText != null)
            messageText.text = "";
    }

    private void Update()
    {
        if (playerInRange && !opened && Input.GetKeyDown(KeyCode.E))
        {
            opened = true;

            PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
            if (inventory != null)
            {
                inventory.hasKey = true;
            }

            // Switch chest from closed to open
            if (closedChestVisual != null) closedChestVisual.SetActive(false);
            if (openedChestVisual != null) openedChestVisual.SetActive(true);

            if (messageText != null)
            {
                messageText.text = "You found the magic key!";
                CancelInvoke(nameof(ClearMessage));
                Invoke(nameof(ClearMessage), 2f);
            }
        }
    }

    private void ClearMessage()
    {
        if (messageText != null)
            messageText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (!opened && messageText != null)
            {
                messageText.text = "Press E to open chest";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (messageText != null)
            {
                messageText.text = "";
            }
        }
    }
}