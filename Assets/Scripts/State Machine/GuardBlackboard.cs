using UnityEngine;
using UnityEngine.AI;

public class GuardBlackboard : MonoBehaviour
{
    public GameObject player;
    
    [Header("Patrol")]
    public Transform[] patrolPoints;
    public NavMeshAgent agent;
    public int currentPatrolIndex;
    
    [Header("Perception")]
    public bool playerInSight;
    public Vector3 lastSeenPosition;
}
