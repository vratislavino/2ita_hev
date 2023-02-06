using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{
    public override void DoStep() {
        Vector3 dir = DataHolder.Instance.Player.transform.position - agent.transform.position;
        dir.y = 0;
        dir = -dir;

        agent.SetDestination(agent.transform.position + dir);
    }

    public override State TryToChangeState() {

        if (Vector3.Distance(DataHolder.Instance.Player.transform.position, agent.transform.position) > 10) {
            return new IdleState();
        } else {
            if (DataHolder.Instance.Player.CurrentSymbol == symbol.CurrentSymbol) {
                return new IdleState();
            } else {
                if (DataHolder.Instance.Player.WouldEnemyWin(symbol.CurrentSymbol.Value)) {
                    return new AttackState();
                } else {
                    return null;
                }
            }
        }
        return null;
    }
}
