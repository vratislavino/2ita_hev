using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PlayerMovement2D : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask ignorePlayer;

    private bool isGrounded = false;
    private bool jumpedInAir = false;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void CheckIsGrounded() {
        var hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, ignorePlayer);
        if (hit.collider == null) {
            isGrounded = false;
        } else {
            isGrounded = true;
            jumpedInAir = false;
        }
    }

    // Update is called once per frame
    void Update() {
        CheckIsGrounded();

        float moveX = 0;
        float moveY = rigidbody.velocity.y;
        if (Input.GetKey(KeyCode.A)) {
            moveX = -speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX = speed;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded) {
                moveY = jumpForce;
                isGrounded = false;
            } else {
                if (!jumpedInAir) {
                    moveY = jumpForce;
                    jumpedInAir = true;
                }
            }
        }

        rigidbody.velocity = new Vector2(moveX, moveY);
        // referenèní a hodnotový datový typ - struct vs class
    }
}