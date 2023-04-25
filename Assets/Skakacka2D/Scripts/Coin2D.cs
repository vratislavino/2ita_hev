using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer sr;

    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponentInParent<PlayerMovement2D>();
        if(player != null) {
            //sr.color = GetComponent<SpriteRenderer>().color;
            //
            Debug.Log("asasd");
            animator.SetTrigger("Destroy");
            Destroy(gameObject,1f);
        }
    }
}
