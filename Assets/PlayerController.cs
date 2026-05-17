using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public Transform cameraTransform;
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float mouseSensitivity = 100f;
    
    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("IsJumping", false);
        }

        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        controller.Move(moveDirection * speed * Time.deltaTime);

        controller.Move(moveDirection * speed * Time.deltaTime);
        animator.SetFloat("Speed", moveDirection.magnitude);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
            AudioManager.Instance.PlaySFX(AudioManager.Instance.jump);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        

    }
}
