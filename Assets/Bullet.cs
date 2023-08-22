using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float destroyXPosition = 60;
    private Rigidbody2D rb;

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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crab"))
        {
            Debug.Log("Collision with player object");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crab"))
        {
            // Trigger-based collision with an object with the specified tag
            Debug.Log("Trigger collision with other object");
        }
    }

}
