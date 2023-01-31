using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : StaticSymbol
{
    private void Awake() {
        DataHolder.Instance.SetPlayerReference(this);
    }

    protected override void Start() {
        base.Start();
        StartCoroutine(SwitchSymbol());
    }

    IEnumerator SwitchSymbol() {
        while (true) {
            yield return new WaitForSeconds(1);
            CurrentSymbol = GenerateRandomSymbol();
        }
    }

    public bool WouldEnemyWin(SymbolEnum enemy) {
        if(CurrentSymbol == SymbolEnum.Rock) {
            if (enemy == SymbolEnum.Paper)
                return true;
            if (enemy == SymbolEnum.Scissors)
                return false;
        }
        if (CurrentSymbol == SymbolEnum.Scissors) {
            if (enemy == SymbolEnum.Paper)
                return false;
            if (enemy == SymbolEnum.Rock)
                return true;
        }
        if (CurrentSymbol == SymbolEnum.Paper) {
            if (enemy == SymbolEnum.Rock)
                return false;
            if (enemy == SymbolEnum.Scissors)
                return true;
        }
        return false;
    }

}

public enum SymbolEnum
{
    Rock, Paper, Scissors
}