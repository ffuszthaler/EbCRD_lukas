using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float closestDistanceToPlayer;
    [SerializeField] private float maximumAngle;

    private Vector3 previousPlayerPosition;
    private float maximumDistanceFromPlayer;
    private Transform playerTransform;

    void OnCameraMovement(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();

        CameraRotationYAxis(inputVector);
        CameraRotationXAxis(inputVector);
    }

    void OnCameraZoom(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();
        CameraZoom(inputVector);
    }

    void CameraRotationYAxis(Vector2 inputVector)
    {
        // camera rotates around player
        transform.RotateAround(playerTransform.position, new Vector3(0, 1, 0), inputVector.x);
        // change player rotation according to camera
        // playerTransform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    void CameraRotationXAxis(Vector2 inputVector)
    {
        var up = inputVector.y * 0.2f;

        var originalPosition = transform.position;
        var originalRotation = transform.rotation;

        transform.RotateAround(playerTransform.position, transform.right, up);

        if (Vector3.Angle(playerTransform.forward, transform.forward) > maximumAngle)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }

    void CameraZoom(Vector2 inputVector)
    {
        var shiftValue = inputVector.y * 0.05f;
        transform.Translate(new Vector3(0, 0, shiftValue));

        var distance = Mathf.Abs(Vector3.Distance(transform.position, playerTransform.position));

        if (distance > maximumDistanceFromPlayer || distance < closestDistanceToPlayer)
        {
            // invert previous shift
            transform.Translate(new Vector3(0, 0, -shiftValue));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        previousPlayerPosition = playerObject.transform.position;
        maximumDistanceFromPlayer = Mathf.Abs(Vector3.Distance(transform.position, previousPlayerPosition));

        playerTransform = playerObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentPlayerPosition = playerObject.transform.position;

        var deltaPlayerPosition = currentPlayerPosition - previousPlayerPosition;
        transform.position += deltaPlayerPosition;

        previousPlayerPosition = currentPlayerPosition;
    }
}