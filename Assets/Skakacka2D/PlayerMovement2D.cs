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
    private List<Transform> groundChecks;

    [SerializeField]
    private LayerMask ignorePlayer;

    private bool isGrounded = false;
    private bool jumpedInAir = false;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void CheckIsGrounded() {
        bool isHit = false;
        for (int i = 0; i < groundChecks.Count; i++) {
            var hit = Physics2D.Raycast(groundChecks[i].position, Vector2.down, 0.1f, ignorePlayer);
            if (hit.collider == null) {
                
            } else {
                isHit = true;
                jumpedInAir = false;
            }
        }
        isGrounded = isHit;
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
        /*
            Jump
            Speed
            Zpomalení èasu
         */
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