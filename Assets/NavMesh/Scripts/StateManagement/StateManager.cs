using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private State currentState;

    public State CurrentState {
        get { return currentState; }
    }

}
