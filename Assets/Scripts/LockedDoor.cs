using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    void Update()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();

        if (inventory != null && inventory.hasKey)
        {
            gameObject.SetActive(false);
        }
    }
}