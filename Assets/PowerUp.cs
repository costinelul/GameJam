using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 2f;
    public float duration = 2f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other) );
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        player.transform.localScale /= multiplier;
        PlayerMovement stats = player.GetComponent<PlayerMovement>();
        stats.speed *= multiplier;
        stats.jump *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.transform.localScale *= multiplier;
        stats.speed /= multiplier;
        stats.jump /= multiplier;

        Destroy(gameObject);
    }
}
