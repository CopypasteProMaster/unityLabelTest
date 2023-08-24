
using UnityEngine;
using UnityEngine.InputSystem;

public class josticjforlook : MonoBehaviour
{
    public Transform playerBody;
    public FixedJoystick lookJoystick;
    public float sensitivity = 100f;
    private Vector2 rotation = Vector2.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the joystick input values for rotation
        float inputX = lookJoystick.Horizontal;
        float inputY = lookJoystick.Vertical;

        // Calculate the camera rotation amount based on sensitivity and time
        rotation.x += inputX * sensitivity * Time.deltaTime;
        rotation.y -= inputY * sensitivity * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);

        // Apply the rotation to the player and camera
        playerBody.localRotation = Quaternion.Euler(0f, rotation.x, 0f);
        transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, 0f);
    }
}