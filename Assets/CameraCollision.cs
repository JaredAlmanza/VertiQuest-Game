using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform player;
    public float distance = 4f;
    public float minDistance = 0.5f;
    public float smoothSpeed = 10f;
    public float collisionRadius = 0.3f;
    public LayerMask collisionLayers;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        Vector3 direction = (transform.position - player.position).normalized;
        Vector3 desiredCameraPos = player.position + direction * distance;

        RaycastHit hit;
        if (Physics.SphereCast(player.position, collisionRadius, direction, out hit, distance, collisionLayers))
        {
            float adjustedDistance = Mathf.Clamp(hit.distance, minDistance, distance);
            desiredCameraPos = player.position + direction * adjustedDistance;
        }

        transform.position = Vector3.SmoothDamp(transform.position, desiredCameraPos, ref currentVelocity, Time.deltaTime * smoothSpeed);
        transform.LookAt(player);
    }
}

