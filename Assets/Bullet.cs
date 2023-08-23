using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float destroyXPosition = 60;
    private Rigidbody2D rb;
    public float damage = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        if (transform.position.x >= destroyXPosition || transform.position.x <= -destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crab"))
        {
            Crab crab = other.GetComponent<Crab>();
            crab.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
