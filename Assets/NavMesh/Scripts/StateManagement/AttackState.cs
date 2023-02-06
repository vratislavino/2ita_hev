using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void DoStep() {
        agent.SetDestination(DataHolder.Instance.Player.transform.position);
    }

    public override State TryToChangeState() {
        // idle, pokud hráè utekl
        // flee, pokud hráè má lepší symbol

        if (Vector3.Distance(DataHolder.Instance.Player.transform.position, agent.transform.position) > 10) {
            return new IdleState();
        } else {
            if (DataHolder.Instance.Player.CurrentSymbol == symbol.CurrentSymbol) {
                return new IdleState();
            } else {
                if (DataHolder.Instance.Player.WouldEnemyWin(symbol.CurrentSymbol.Value)) {
                    return null;
                } else {
                    return new FleeState();
                }
            }
        }
        return null;
    }
}
