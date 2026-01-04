using UnityEngine;
using UnityEngine.AI;

public class GuardBlackboard : MonoBehaviour
{
    public GameObject player;
    
    [Header("Patrol")]
    public Transform[] patrolPoints;
    public float patrolSpeed = 0f;
    public float alertPatrolSpeed = 10;
    public NavMeshAgent agent;
    public int currentPatrolIndex;
    
    [Header("Perception")]
    public bool playerInSight;
    public Vector3 lastSeenPosition;
    
    [Header("Chase Memory")]
    public float timeSinceLastSeen;
	public float waitTimeAtLastPosition;

	[Header("Room")] 
	public bool isAlert = false;
	public GuardBlackboard[] partners;
	

}
