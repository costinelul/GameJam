using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;

    private bool isPlayerRight;

    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Flip();
        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            
            nextFireTime = Time.time + fireRate;
        }
    }

    void Flip()
    {
        if (player.position.x > transform.position.x)
        {
            if (!isPlayerRight)
            {
                isPlayerRight = true;
                transform.Rotate(0, 180, 0);
            }
        }

        if (player.position.x < transform.position.x)
        {
            if (isPlayerRight)
            {
                isPlayerRight = false;
                transform.Rotate(0, 180, 0);
            }
        }
    }
}
