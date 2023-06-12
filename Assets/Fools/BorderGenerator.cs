using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderGenerator : MonoBehaviour
{
    [SerializeField]
    float density = 1;

    [SerializeField]
    float radius = 6;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls() {
        float x, y;
        GameObject g;
        
        for(float uhel = 0; uhel <= 360; uhel += density) {
            x = Mathf.Cos(uhel * Mathf.PI/180) * radius;
            y = Mathf.Sin(uhel * Mathf.PI/180) * radius;

            g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g.transform.position = new Vector3(x, 0.5f, y);
            g.transform.rotation = Quaternion.Euler(0, -uhel, 0);
        }
    }
}
