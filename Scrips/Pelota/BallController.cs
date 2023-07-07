using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Ignore vertical component of camera's forward direction

        // Rotate the movement vector to align with the camera's forward direction
        movement = Quaternion.LookRotation(cameraForward) * movement;

        rb.AddForce(movement * moveSpeed);
    }
}