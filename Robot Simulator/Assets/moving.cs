using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RobotMovement : MonoBehaviour
{
    public float moveForce = 50f;
    public float turnTorque = 10f;
    public float maxSpeed = 10f;
    public float inputDeadzone = 0.1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Zorg voor realistisch stoppen
        rb.drag = 2f;
        rb.angularDrag = 5f;
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");   // W/S of ↑/↓
        float turnInput = Input.GetAxis("Horizontal"); // A/D of ←/→

        // Kleine inputs negeren (deadzone)
        if (Mathf.Abs(moveInput) < inputDeadzone) moveInput = 0;
        if (Mathf.Abs(turnInput) < inputDeadzone) turnInput = 0;

        // Alleen kracht toevoegen als snelheid nog onder limiet is
        if (moveInput != 0 && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * moveForce);
        }

        if (turnInput != 0)
        {
            rb.AddTorque(Vector3.up * turnInput * turnTorque);
        }

        // Geen noodzaak om handmatig velocity = 0 te doen; drag zorgt voor geleidelijke stop
    }
}
