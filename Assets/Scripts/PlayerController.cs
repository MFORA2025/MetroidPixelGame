using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float jumpHeight = 10f;
    private Rigidbody2D rb;
    private bool betterWeapon;
    public float bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shooting();
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        if(horizontalInput > 0)
        {
            transform.localScale = new Vector3(3.182355f, 3.182355f, 3.182355f);
        }
        else if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-3.182355f, 3.182355f, 3.182355f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }


    }
    void Shooting()
    {
        // Determine the direction based on the player's scale
        float direction = Mathf.Sign(transform.localScale.x);

        // Calculate the spawn position of the bullet
        Vector3 spawnPosition = transform.position + new Vector3(direction, 0f, 0f);

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // Get the bullet's rigidbody component
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Set the velocity of the bullet to move in the determined direction
        bulletRigidbody.velocity = new Vector2(direction * bulletSpeed, 0f);
    }
}
