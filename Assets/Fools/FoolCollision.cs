using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision");
        FoolSpawner.Instance.StopSpawn();
    }
}
