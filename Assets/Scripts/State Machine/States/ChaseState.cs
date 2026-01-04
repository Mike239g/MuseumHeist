using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Guard Chase", fileName = "Chase State")]
public class ChaseState : State
{
    public float repathInterval = 0.2f;
    private float repathTimer;

    public override void EnterState(StateMachine sm)
    {
        repathTimer = 0f;
    }

    public override void UpdateState(StateMachine sm)
    {
        var bb = sm.blackboard;

        if (bb.player == null)
            return;
        
        repathTimer -= Time.deltaTime;

        if (repathTimer <= 0f)
        {
            bb.agent.SetDestination(bb.player.transform.position);
            bb.lastSeenPosition = bb.player.transform.position;
            repathTimer = repathInterval;
        }
    }

    public override void ExitState(StateMachine sm)
    {
        repathTimer = 0f;
    }
}
