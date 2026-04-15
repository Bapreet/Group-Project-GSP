using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CreatureEnemy : MonoBehaviour
{
    public float moveSpeed = 1.2f;
    public int currentHealth = 4;
    public int enemyIndex = 1;
    public UIManager uiManager;

    private Rigidbody2D rb;
    private Transform player;
    private bool isActive = false;
    private bool canDamagePlayer = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        if (uiManager != null)
        {
            uiManager.UpdateEnemyHealth(enemyIndex, currentHealth);
        }
        else
        {
            Debug.Log("UIManager missing on " + gameObject.name);
        }
    }

    void FixedUpdate()
    {
        if (!isActive) return;
        if (player == null) return;

        Vector2 direction = ((Vector2)player.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public void ActivateEnemy()
    {
        isActive = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        Debug.Log(gameObject.name + " health = " + currentHealth);

        if (uiManager != null)
        {
            uiManager.UpdateEnemyHealth(enemyIndex, currentHealth);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDamagePlayer)
        {
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
            if (playerCombat != null)
            {
                playerCombat.TakeDamage(1);
                canDamagePlayer = false;
                Invoke(nameof(ResetDamage), 1f);
            }
        }
    }

    void ResetDamage()
    {
        canDamagePlayer = true;
    }
}