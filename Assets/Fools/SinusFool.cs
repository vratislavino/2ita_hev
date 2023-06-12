using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusFool : NormalFool
{
    [SerializeField]
    private int maxAngle;

    [SerializeField]
    private float rotationChangeSpeed = 1;

    private bool goinLeft;
    private float rotation;

    protected override void Move() {

        if(goinLeft) {
            transform.Rotate(Vector3.up * rotationChangeSpeed * Time.deltaTime);
            rotation += rotationChangeSpeed * Time.deltaTime;
            if(rotation >= maxAngle) {
                goinLeft = !goinLeft;
            }
        } else {
            transform.Rotate(-Vector3.up * rotationChangeSpeed * Time.deltaTime);
            rotation -= rotationChangeSpeed * Time.deltaTime;
            if (rotation <= -maxAngle) {
                goinLeft = !goinLeft;
            }
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
