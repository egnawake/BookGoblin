using UnityEngine;

public class CameraPitch : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minAngle = -40f;
    [SerializeField] private float maxAngle = 60f;

    private float xRotation = 0;

    private void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 eulerAngles = transform.localEulerAngles;
        xRotation = xRotation - mouseY * sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);
        eulerAngles.x = xRotation;
        transform.localEulerAngles = eulerAngles;
    }
}
