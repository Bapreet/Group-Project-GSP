using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Sprite downSprite;
    public Sprite upSprite;
    public RuntimeAnimatorController sideWalkController;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Horizontal movement = use walk animation
        if (movement.x > 0)
        {
            if (anim != null) anim.enabled = true;
            sr.flipX = false;
        }
        else if (movement.x < 0)
        {
            if (anim != null) anim.enabled = true;
            sr.flipX = true;
        }
        // Vertical movement = use single sprites
        else if (movement.y > 0)
        {
            if (anim != null) anim.enabled = false;
            sr.flipX = false;
            sr.sprite = upSprite;
        }
        else if (movement.y < 0)
        {
            if (anim != null) anim.enabled = false;
            sr.flipX = false;
            sr.sprite = downSprite;
        }
        else
        {
            if (anim != null) anim.enabled = false;
            sr.flipX = false;
            sr.sprite = downSprite;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * speed;
    }
}