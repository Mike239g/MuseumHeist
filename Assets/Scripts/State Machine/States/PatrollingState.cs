using UnityEngine;
[CreateAssetMenu(menuName = "FSM/States/Guard Patrol", fileName = "Patrolling State")]
public class PatrollingState : State
{
    public float reachDistance = 0.5f;
    
    public override void EnterState(StateMachine sm)
    {
        SetDestination(sm);
    }
    
    public override void UpdateState(StateMachine sm)
    {
        GuardBlackboard bb = sm.blackboard;

        if (bb.patrolPoints.Length == 0)
            return;

        if (!bb.agent.pathPending && bb.agent.remainingDistance <= reachDistance)
        {
            bb.currentPatrolIndex = (bb.currentPatrolIndex + 1) % bb.patrolPoints.Length;
            SetDestination(sm);
        }
    }
    void SetDestination(StateMachine sm)
    {
        GuardBlackboard bb = sm.blackboard;

        bb.agent.SetDestination(bb.patrolPoints[bb.currentPatrolIndex].position);
    }
}
