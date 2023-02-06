using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSymbolCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        var enemy = other.GetComponentInParent<StaticSymbol>();
        if(enemy != null) {
            var player = GetComponentInParent<Symbol>();
            if(player.WouldEnemyWin(enemy.CurrentSymbol.Value)) {
                Time.timeScale = 0;
            } else {
                Destroy(enemy.gameObject);
            }
        } else {
            Debug.Log(other, other);
        }
    }
}
