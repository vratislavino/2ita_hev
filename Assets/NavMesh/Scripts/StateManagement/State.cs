using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;
    protected StaticSymbol symbol;

    public virtual void InitState(NavMeshAgent agent, StaticSymbol symbol) { 
        this.agent = agent;
        this.symbol = symbol;
    }

    public abstract State TryToChangeState();

    public abstract void DoStep();
}
