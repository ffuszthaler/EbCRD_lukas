using System;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float transformMoveSpeed = 1f;
    public float physicalMoveSpeed = 1f;
    public float physicalJumpHeight = 1f;

    private uint switchState;

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

        AkSoundEngine.PostEvent("Play_Player_Jump", gameObject);
        rigidBody.AddForce(transform.up * physicalJumpHeight, ForceMode.Impulse);
    }

    public void WalkSoundEvent()
    {
        Debug.Log("hi");
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

        if (!isWalking)
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            return;
        }

        if (movementType == MovementType.TransformBased)
        {
            RotatePlayer(moveBy);
            transform.Translate(Vector3.forward * (transformMoveSpeed * Time.deltaTime));
        }
        else if (movementType == MovementType.PhysicalBased)
        {
            rigidBody.AddForce(moveBy * physicalMoveSpeed, ForceMode.Acceleration);
        }
    }

    private void RotatePlayer(Vector3 rotation)
    {
        rotation = Vector3.Normalize(rotation);

        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        var rotationY = 90 * rotation.x;

        if (rotation.z < 0)
        {
            transform.Rotate(0, 180, 0);
            rotationY *= -1;
        }

        transform.Rotate(0, rotationY, 0);
    }

    private void Awake()
    {
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