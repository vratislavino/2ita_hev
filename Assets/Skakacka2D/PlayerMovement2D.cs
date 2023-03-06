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
    private int maxJumps = 2;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask ignorePlayer;

    private bool isGrounded = false;
    private int jumpCount;
    private bool ableToJump = true;

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
            jumpCount = maxJumps;
        }
    }

    // DOUBLE JUMP JE TROCHU... TROOOOOOOooOŠIÈKU BUGGY :) 

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
            if (jumpCount > 0 && ableToJump) {
                StartCoroutine(ResetJump());
                jumpCount--;
                moveY = jumpForce;
                //rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        rigidbody.velocity = new Vector2(moveX, moveY);
        // referenèní a hodnotový datový typ - struct vs class
    }

    IEnumerator ResetJump() {
        ableToJump = false;
        yield return new WaitForSeconds(0.1f);
        ableToJump = true;
    }
}