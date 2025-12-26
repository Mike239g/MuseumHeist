using System;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;
    
    public GuardBlackboard blackboard;

    private void Awake()
    {
        blackboard = GetComponent<GuardBlackboard>();
        blackboard.agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        blackboard.player = GameObject.FindGameObjectWithTag("Player");
        changeState(initialState);
    }

    public void changeState(State state)
    {
        if(currentState == state || state == null)
            return;
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        
        currentState = state;
        currentState.EnterState(this);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
            currentState.CheckTransitions(this);
        }
    }
    
}