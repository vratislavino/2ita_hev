using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolCatcher : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    private LayerMask foolLayerMask;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 50f, foolLayerMask)) {
                var fool = hit.collider.GetComponentInParent<Fool>();
                if(fool != null) {
                    fool.OnClicked();
                }
            }
        }
    }
}
