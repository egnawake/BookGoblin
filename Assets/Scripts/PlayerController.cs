using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float airMoveSpeed = 0.4f;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float gravity = -9.8f;

    private CharacterController charController;
    private float yRotation = 0;
    private Vector3 velocity;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateRotation();

        Vector3 newVelocity = FindVelocity();
        charController.Move(newVelocity);

        velocity = newVelocity;
    }

    private void UpdateRotation()
    {
        Vector3 rotation = transform.localEulerAngles;

        float mouseX = Input.GetAxis("Mouse X");
        yRotation = yRotation + (mouseX * rotationSpeed * Time.deltaTime);

        transform.localEulerAngles = Vector3.up * yRotation;
    }

    private Vector3 FindVelocity()
    {
        bool grounded = charController.isGrounded;

        Vector3 newVelocity = Vector3.zero;

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
            .normalized;

        if (grounded)
        {
            newVelocity = transform.rotation * input * moveSpeed * Time.deltaTime;
        }
        else
        {
            newVelocity = transform.rotation * input * airMoveSpeed * Time.deltaTime;
            newVelocity += Vector3.up * (velocity.y + gravity * Time.deltaTime);
        }

        return newVelocity;
    }
}
