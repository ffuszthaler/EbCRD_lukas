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

    [SerializeField] private Animator animator;
    private bool isWalking;
    private bool isJumpingOrFalling = false;

    void OnMovement(InputValue input)
    {
        var inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        if (isJumpingOrFalling)
            return;

        rigidBody.AddForce(transform.up * physicalJumpHeight, ForceMode.Impulse);
    }

    void ExecuteMovement()
    {
        isJumpingOrFalling = GetComponent<Rigidbody>().velocity.y < -.035 ||
                             GetComponent<Rigidbody>().velocity.y > 0.00001;

        if (moveBy == Vector3.zero)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        animator.SetBool("walk", isWalking);
        animator.SetBool("jump", isJumpingOrFalling);

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