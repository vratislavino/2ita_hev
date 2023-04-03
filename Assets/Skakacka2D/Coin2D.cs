using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponentInParent<PlayerMovement2D>();
        if(player != null) {
            sr.color = GetComponent<SpriteRenderer>().color;
            //Destroy(gameObject);
        }
    }
}
