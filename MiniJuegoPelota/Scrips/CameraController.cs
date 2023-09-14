using UnityEngine;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance = 5f;
    [SerializeField] float sensitivity = 2f;
    [SerializeField] float rotationSmoothness = 5f;

    private float currentX = 0f;
    private float currentY = 0f;

    private void Update()
    {
        // Get the mouse input
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp the vertical rotation to avoid flipping
        currentY = Mathf.Clamp(currentY, -90f, 90f);
    }

    private void LateUpdate()
    {
        // Smoothly interpolate the current rotation towards the target rotation
        Quaternion targetRotation = Quaternion.Euler(currentY, currentX, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothness);

        // Calculate the desired camera position relative to the target
        Vector3 offset = transform.rotation * new Vector3(0f, 0f, -distance);

        // Set the camera position
        transform.position = target.position + offset;
    }
}