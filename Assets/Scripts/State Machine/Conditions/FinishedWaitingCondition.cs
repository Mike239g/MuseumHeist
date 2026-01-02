using UnityEngine;
[CreateAssetMenu(menuName = "FSM/Conditions/Finished Waiting At Last Position", fileName = "Finished Waiting At Last Position")]
public class FinishedWaitingCondition : Condition
{
    public override bool Check(StateMachine sm)
    {
        if (sm.currentState is GuardCheckLastPositionState state)
        {
            return state.FinishedWaiting(sm);
        }
        return false;
    }
}
