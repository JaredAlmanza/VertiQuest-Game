using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform cameraPivot;
    public float mouseSensitivity = 3.5f;
    public float distanceFromPlayer = 3f;
    public float minYAngle = -30f;
    public float maxYAngle = 60f;
    public bool rotatePlayer = true; 

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        cameraPivot.rotation = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = cameraPivot.position - cameraPivot.forward * distanceFromPlayer;
        transform.LookAt(cameraPivot);

        if (rotatePlayer)
        {
            player.rotation = Quaternion.Euler(0f, yaw, 0f);
        }
    }
}
