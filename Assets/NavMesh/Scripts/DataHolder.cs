using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder
{
    private static DataHolder instance = new DataHolder();
    public static DataHolder Instance => instance;

    private DataHolder() { }

    // -------------------------- ^ singleton things
    // -------------------------- v our things :)

    List<StaticSymbol> enemies = new List<StaticSymbol>();
    public List<StaticSymbol> Enemies => enemies;

    Symbol playerRef;
    public Symbol Player => playerRef;

    public void SetPlayerReference(Symbol player) {
        this.playerRef = player;
    }

    public void AddEnemy(StaticSymbol enemy) {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(StaticSymbol enemy) {
        enemies.Remove(enemy);
        if(enemies.Count == 0) {
            Debug.Log("Hr·Ë vyhr·l!");
            Time.timeScale = 0;
        }
    }
}
