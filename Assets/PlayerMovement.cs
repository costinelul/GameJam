using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private bool isFacingRight = true;

    private float Move;

    public bool isJumping;

    public Rigidbody2D player;

    public CoinManager coinManager;

    void Start()
    {
        isJumping = true;
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        Flip();

        player.velocity = new Vector2(speed * Move, player.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            player.AddForce(new Vector2(player.velocity.x, jump));
        }
    }

    private void Flip()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if(isFacingRight is true)
            {
                isFacingRight = false;
                transform.Rotate(0, 180, 0);
            }
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if(isFacingRight is false)
            {
                isFacingRight = true;
                transform.Rotate(0, 180, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(player);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinManager.coinCount++;
        }
    }
}
