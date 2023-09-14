using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class BallController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Jump")]
    public KeyCode JumpKey = KeyCode.Space;
    [SerializeField] float GroundCheckDistance = 0.7f;
    [SerializeField] float JumpForce = 50f;
    [SerializeField] int ExtraJumps = 0;
    [SerializeField] float JumpColdDown = 0.4f;

    [Header("Setings")]
    [SerializeField] bool HideCursor;
    [SerializeField] bool LockCursor;

    private Rigidbody rb;
    private float HorizontalMove;
    private float VerticalMove;
    private bool IsGroundead;
    private bool Jump;
    private int JumpCount;
    private float JumpTime;
    private Vector3 movement;
    private Vector3 cameraForward;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsGroundead = true;
        Jump = false;
        SetUp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey)) { Jump = true; }

        HorizontalMove = Input.GetAxis("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");

        movement = new Vector3(HorizontalMove, 0f, VerticalMove);

        IsGroundead = Physics.Raycast(transform.position, -Vector3.up, GroundCheckDistance);

        JumpCount = IsGroundead ? 0 : JumpCount;
        JumpTime = JumpTime <= JumpColdDown ? JumpTime + Time.deltaTime : JumpColdDown;

        cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Ignore vertical component of camera's forward direction

        // Rotate the movement vector to align with the camera's forward direction

        movement = Quaternion.LookRotation(cameraForward) * movement;
       
    }

    private void FixedUpdate()
    {
        if (Jump && JumpCount < ExtraJumps && JumpTime >= JumpColdDown)
        {

            Jump = false;
            JumpCount++;
            JumpTime = 0;
            rb.AddForce(new Vector3(0, JumpForce), ForceMode.Impulse);

        }

        rb.AddForce(movement * moveSpeed);
    }

    private void SetUp()
    {
        Cursor.lockState = LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = HideCursor ? false : true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(0, -GroundCheckDistance, 0) + transform.position);
        
    }

}