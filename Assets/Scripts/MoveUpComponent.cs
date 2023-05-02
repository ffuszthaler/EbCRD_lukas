using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveUpComponent : MonoBehaviour
{
    // public float speed = 0.1f;
    
    [SerializeField] private MovementType movementType = 0;

    private Vector3 moveBy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteMovement();
    }

    void ExecuteMovement()
    {
        if (movementType == MovementType.TransformBased)
        {
            transform.position += moveBy;
        }
        else if (movementType == MovementType.PhysicalBased)
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.AddForce(moveBy * 2, ForceMode.Acceleration);
        }
    }
    
    void OnMovement(InputValue input)
    {
        var inputValue = input.Get<Vector2>();
        // print(inputValue);
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
        //transform.position += new Vector3(inputValue.x, 0, inputValue.y)*_speed;

    }
}
