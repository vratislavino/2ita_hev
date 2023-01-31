using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour
{
    private State currentState;

    public State CurrentState {
        get { return currentState; }
    }

    private void Start() {
        currentState = new IdleState();
        currentState.InitState(GetComponent<NavMeshAgent>());
    }

    private void Update() {
        CurrentState.DoStep();
        // možnost pøepnutí stavu
    }

}
