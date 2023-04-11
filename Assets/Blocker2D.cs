using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker2D : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponentInParent<Rigidbody2D>();
        if (player) {
            player.AddForce((Vector2.left + Vector2.up*0.01f) * 1000);
        }
    }
}
