using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private MovementType movementType = 0;
    private Rigidbody rigidBody;
    
    private Vector3 moveBy;
    
    void OnMovement(InputValue input)
    {
        var inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump()
    {
        rigidBody.AddForce(transform.up * 3, ForceMode.Impulse);
    }
    
    void ExecuteMovement()
    {
        if (movementType == MovementType.TransformBased)
        {
            transform.position += moveBy;
        }
        else if (movementType == MovementType.PhysicalBased)
        {
            // change multiplication value to have greater effect
            rigidBody.AddForce(moveBy * 5, ForceMode.Acceleration);
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
