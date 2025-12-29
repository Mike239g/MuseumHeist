using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public float viewDistance = 10f;
    public float viewAngle = 90f;
    public LayerMask obstacleMask;

    private GuardBlackboard bb;

    void Awake()
    {
        bb = GetComponent<GuardBlackboard>();
    }

    void Update()
    {
        if (bb.player == null)
            return;

        bool detected = PlayerInFOV();

        bb.playerInSight = detected;

        if (detected)
            bb.lastSeenPosition = bb.player.transform.position;
        
        if (bb.playerInSight)
        {
            bb.timeSinceLastSeen = 0f;
            bb.lastSeenPosition = bb.player.transform.position;
        }
        else
        {
            bb.timeSinceLastSeen += Time.deltaTime;
        }

    }

    bool PlayerInFOV()
    {
        Transform playerTransform = bb.player.transform;

        Vector3 dirToPlayer = (playerTransform.position - transform.position).normalized;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > viewDistance)
            return false;

        float angleToPlayer = Vector3.Angle(transform.forward, dirToPlayer);

        if (angleToPlayer > viewAngle * 0.5f)
            return false;

        if (Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit, distanceToPlayer, ~obstacleMask))
        {
            return hit.collider.gameObject == bb.player;
        }

        return false;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Vector3 left =
            Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward;
        Vector3 right =
            Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + left * viewDistance);
        Gizmos.DrawLine(transform.position, transform.position + right * viewDistance);

        if (bb != null && bb.player != null)
        {
            Gizmos.color = bb.playerInSight ? Color.red : Color.gray;
            Gizmos.DrawLine(transform.position, bb.player.transform.position);
        }
    }
}