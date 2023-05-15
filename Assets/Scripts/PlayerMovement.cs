using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float transformMoveSpeed = 1f;

    public float physicalMoveSpeed = 1f;
    public float physicalJumpHeight = 1f;

    [SerializeField] private MovementType movementType = 0;
    private Rigidbody rigidBody;

    private Vector3 moveBy;

    void OnMovement(InputValue input)
    {
        var inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        rigidBody.AddForce(transform.up * physicalJumpHeight, ForceMode.Impulse);
    }

    void ExecuteMovement()
    {
        if (movementType == MovementType.TransformBased)
        {
            transform.Translate(moveBy * (transformMoveSpeed * Time.deltaTime));
        }
        else if (movementType == MovementType.PhysicalBased)
        {
            rigidBody.AddForce(moveBy * physicalMoveSpeed, ForceMode.Acceleration);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteMovement();
    }
}