using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 2f;

    private float currentX = 0f;
    private float currentY = 0f;

    private void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        currentY = Mathf.Clamp(currentY, -90f, 90f);

        Vector3 offset = new Vector3(0f, 0f, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target);
    }
}