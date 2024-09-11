using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float basicSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private Rigidbody rigidBody;
    private float moveSpeed;

    void Start()
    {
        moveSpeed = basicSpeed;
    }

    void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        float moveDirection = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveDirection * moveSpeed * Time.deltaTime;

        rigidBody.MovePosition(rigidBody.position + movement);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = basicSpeed;
        }
    }

    private void Turn()
    {
        float turnDirection = Input.GetAxis("Horizontal");
        float turn = turnDirection * turnSpeed * Time.deltaTime;

        Vector3 rotation = new Vector3(0, turn, 0);
        Quaternion deltaRotation =Quaternion.Euler(rotation);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }
}
