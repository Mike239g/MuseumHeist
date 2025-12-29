using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Conditions/Lost Player", fileName = "Lost Player")]
public class LostPlayerCondition : Condition
{
    public float lostTime = 2f;

    public override bool Check(StateMachine sm)
    {
        if (sm.blackboard == null)
            return false;

        return sm.blackboard.timeSinceLastSeen >= lostTime;
    }
}