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
}