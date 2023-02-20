using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPFire : MonoBehaviour
{
    [SerializeField]
    private Rigidbody ballPrefab;

    [SerializeField]
    private float force;

    private Vector3 rot;
    private Vector3 baseRotation;

    [SerializeField]
    private float sensitivity;

    void Start()
    {
        baseRotation = transform.rotation.eulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        RotateCamera();

        if(Input.GetMouseButtonDown(0)) {
            var rb = Instantiate(ballPrefab, transform.position, Quaternion.identity);

            rb.AddForce(GetDirection() * force, ForceMode.Impulse);
            Destroy(rb.gameObject, 5f);
        }
    }

    private void RotateCamera() {
        rot.x += Input.GetAxis("Mouse Y") * sensitivity;
        rot.y += -Input.GetAxis("Mouse X") * sensitivity;
        rot.z = 0;

        transform.rotation = Quaternion.Euler(baseRotation + rot);
    }

    private Vector3 GetDirection() {
        return transform.forward;
    }
}
