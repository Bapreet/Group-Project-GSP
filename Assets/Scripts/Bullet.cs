using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 8f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
}