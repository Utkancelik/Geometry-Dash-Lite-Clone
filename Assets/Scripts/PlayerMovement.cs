using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Customizable values for movement stuff.
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    // Check if the player is on the ground parameters.
    [SerializeField] private LayerMask checkLayer;
    [SerializeField] private Transform checkPoint;
    [SerializeField] private bool isOnGround;
    [SerializeField] private float checkRadius;


    // Essential components and values for jumping since we use force to jump.
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;


    // Sprite transform, (we mainly use it to rotate player for more accurate rotation.)
    [SerializeField] private Transform playerSpriteTransform;

    /// <summary>
    /// Gets component in the first beginning of the launch of the game.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        GetInput();
    }

    /// <summary>
    /// Moves the player to the right on every frame.
    /// </summary>
    private void MovePlayer()
    {
        transform.position += movementSpeed * Time.deltaTime * Vector3.right;
    }

    /// <summary>
    /// Gets input from player.
    /// Calls function for each input. (Calls Jump function for Spacebar input.)
    /// Space -> Jump
    /// </summary>
    private void GetInput()
    {
        // If player is on the ground then get mouse input and jump.
        if (IsOnGround())
        {
            // Stabilize the rotation of sprite of the player.
            StabilizeTheRotation();

            // Left Click
            if (Input.GetMouseButton(0))
            {
                // Jump
                Jump();
            }
        }
        // if not then rotate the sprite
        else
        {
            RotatePlayerSprite();
        }
    }

    /// <summary>
    /// Makes the character jump with force.
    /// </summary>
    private void Jump()
    {
        // Clear or Reset the velocity on the Rigidbody before jumping
        rb.velocity = Vector2.zero;

        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }


    /// <summary>
    /// Checks if the player is on the ground
    /// Returns true if player is on the ground, returns false otherwise.
    /// </summary>
    private bool IsOnGround()
    {
        isOnGround = Physics2D.OverlapCircle(checkPoint.transform.position, checkRadius, checkLayer);
        return isOnGround;
    }

    /// <summary>
    /// Rotates the player sprite when player is not on the ground (on air.)
    /// </summary>
    private void RotatePlayerSprite()
    {
        playerSpriteTransform.Rotate(100 * rotationSpeed * Time.deltaTime * Vector3.back);
    }

    /// <summary>
    /// When falling on the ground, the player does not sit accurate,
    /// So we need to stabilize the stance of the player.
    /// </summary>
    private void StabilizeTheRotation()
    {
        // Get sprite currently rotation
        Vector3 rotation = playerSpriteTransform.rotation.eulerAngles;
        // Then in the z-axis (which is the only axis we are rotating), round the current rotation
        rotation.z = Mathf.Round(rotation.z / 90) * 90;
        // Lastly assign new rotation value.
        playerSpriteTransform.transform.rotation = Quaternion.Euler(rotation);
    }

}
