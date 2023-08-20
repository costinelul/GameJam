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

}
