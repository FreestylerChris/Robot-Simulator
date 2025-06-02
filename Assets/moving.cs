using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RobotMovement : MonoBehaviour
{
    public float moveForce = 50f;
    public float turnSensitivity = 2f;
    public float maxSpeed = 10f;
    public float inputDeadzone = 0.1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.drag = 2f;
        rb.angularDrag = 5f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");    // W/S
        float strafeInput = Input.GetAxis("Horizontal"); // A/D
        float mouseX = Input.GetAxis("Mouse X");

        // Deadzone toepassen
        if (Mathf.Abs(moveInput) < inputDeadzone) moveInput = 0;
        if (Mathf.Abs(strafeInput) < inputDeadzone) strafeInput = 0;

        Vector3 moveDirection = (transform.forward * moveInput + transform.right * strafeInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            rb.AddForce(moveDirection * moveForce);
        }

        // Dynamische drag
        bool isMoving = moveInput != 0 || strafeInput != 0;
        rb.drag = isMoving ? 2f : 100f;
        rb.angularDrag = isMoving ? 5f : 100f;

        // Draaien met muis
        if (mouseX != 0)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, mouseX * turnSensitivity, 0f));
        }

        // Max snelheid beperken
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
