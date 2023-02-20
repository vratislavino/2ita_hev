using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        if(Input.GetKey(KeyCode.A)) {
            moveX = -speed;
        }
        if(Input.GetKey(KeyCode.D)) { 
            moveX = speed;
        }

        rigidbody.velocity = new Vector2(moveX, rigidbody.velocity.y);
        // referenèní a hodnotový datový typ - struct vs class
        
    }
}
