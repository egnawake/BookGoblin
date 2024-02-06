using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 1f;

    private CharacterController charController;
    private float yRotation = 0;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
            .normalized;

        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = transform.localEulerAngles;
        yRotation = yRotation + (mouseX * rotationSpeed * Time.deltaTime);
        transform.localEulerAngles = Vector3.up * yRotation;

        Vector3 motion = transform.rotation * input * moveSpeed * Time.deltaTime;

        charController.Move(motion);
    }
}
