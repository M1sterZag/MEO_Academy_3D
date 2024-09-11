using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField, Range(1, 90)] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float detectionRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform playerTransform;
    private bool isPlayerInSight;
    private Quaternion initialRotation;

    void Start() 
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        DetectPlayer();

        if (isPlayerInSight)
        {
            RotateTowardsPlayer();
        }
        else
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        float yRotation = Mathf.Sin(Time.time * frequency) * amplitude;
        Quaternion newRotation = Quaternion.Euler(0, yRotation, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, initialRotation * newRotation, frequency * Time.deltaTime);
    }

    private void DetectPlayer()
    {
        Vector3 forward = transform.forward;

        if (Physics.Raycast(transform.position, forward, out RaycastHit hit , detectionRange, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                isPlayerInSight = true;
                return;
            }
        }

        isPlayerInSight = false;
    }

    private void RotateTowardsPlayer()
    {
        Vector3 playerDirection = playerTransform.position - transform.position;
        playerDirection.y = 0;

        Quaternion lookRotation = Quaternion.LookRotation(playerDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * frequency);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isPlayerInSight ? Color.red : Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * detectionRange);   
    }
}
