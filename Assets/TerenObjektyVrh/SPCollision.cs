using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPCollision : MonoBehaviour
{
    public SPGeneration genRef;


    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Ball")) {
            Destroy(gameObject);
            Destroy(collision.collider);
            genRef.Destroyed(this);
        }
    }

}
