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

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Crab>(out Crab crab))
    //    {
    //        crab.TakeDamage();
    //        Debug.Log("Collision with crab");
    //    }
    //    Destroy(gameObject);
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crab"))
        {
            Crab crab = other.GetComponent<Crab>();
            crab.TakeDamage();
            Debug.Log("Trigger collision with crab");
        }
        Destroy(gameObject);
    }
}
