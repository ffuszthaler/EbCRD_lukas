using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float closestDistanceToPlayer;

    private Vector3 previousPlayerPosition;
    private float maximumDistanceFromPlayer;

    void OnCameraMovement(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();

        // Debug.Log("Camera Movement: " + input);
        var playerTransform = playerObject.GetComponent<Transform>();

        // camera rotates around player
        transform.RotateAround(playerTransform.position, new Vector3(0, 1, 0), inputVector.x);

        // change player rotation according to camera
        playerTransform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        // use shiftValue to move camera to/from player
        // *sparkle* magic line of code *sparkle*
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