using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    public abstract void InitState(NavMeshAgent agent);

    public abstract State TryToChangeState();

    public abstract void DoStep();
}
