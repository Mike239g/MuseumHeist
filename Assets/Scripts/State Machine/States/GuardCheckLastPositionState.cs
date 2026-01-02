using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Guard Check Last Position", fileName = "Check Last Position State")]

public class GuardCheckLastPositionState : State
{
    private float timer;

    public override void EnterState(StateMachine sm)
    {
        timer = 0f;

        var bb = sm.blackboard;
        bb.agent.isStopped = false;
        bb.agent.SetDestination(bb.lastSeenPosition);
    }

    public override void UpdateState(StateMachine sm)
    {
        var bb = sm.blackboard;

        // Esperar a llegar
        if (bb.agent.pathPending)
            return;

        if (bb.agent.remainingDistance > bb.agent.stoppingDistance)
            return;
        
        bb.agent.isStopped = true;
        timer += Time.deltaTime;
    }

    public override void ExitState(StateMachine sm)
    {
        sm.blackboard.agent.isStopped = false;
        timer = 0f;
    }

    public bool FinishedWaiting(StateMachine sm)
    {
        return timer >= sm.blackboard.waitTimeAtLastPosition;
    }
}
