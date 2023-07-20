using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BallController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float FuerzaDeSalto = 2f;


    public KeyCode TeclaSaltar;

    private Rigidbody rb;
    private bool TocandoSuelo;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        TocandoSuelo = true;
    }
    private void Update()
    {
        if (TocandoSuelo)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");



            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            if (Input.GetKeyDown(TeclaSaltar))
            {
                movement.y = FuerzaDeSalto;
                TocandoSuelo = false;
            }
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0f; // Ignore vertical component of camera's forward direction

            // Rotate the movement vector to align with the camera's forward direction
            movement = Quaternion.LookRotation(cameraForward) * movement;
            rb.AddForce(movement * moveSpeed);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            TocandoSuelo = true;
        }
    }
}