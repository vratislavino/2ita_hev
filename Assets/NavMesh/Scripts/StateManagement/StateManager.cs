using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateManager : MonoBehaviour
{
    private NavMeshAgent agentCache;
    private StaticSymbol symbolCache;

    private State currentState;

    public State CurrentState {
        get { return currentState; }
    }

    private void Start() {
        agentCache = GetComponent<NavMeshAgent>();
        symbolCache = GetComponent<StaticSymbol>();
        ChangeState(new IdleState());
    }

    private void ChangeState(State newState) {
        currentState = newState;
        currentState.InitState(agentCache, symbolCache);
        Debug.Log("Changed State -> " + newState.GetType());
    }

    private void Update() {
        CurrentState.DoStep();

        var newState = CurrentState.TryToChangeState();
        if(newState != null) {
            ChangeState(newState);
        }
    }

}
