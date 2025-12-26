using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Conditions/Player In Sight")]
public class PlayerInSightCondition : Condition
{
    public override bool Check(StateMachine sm)
    {
        if (sm.blackboard == null)
            return false;

        return sm.blackboard.playerInSight;
    }
}