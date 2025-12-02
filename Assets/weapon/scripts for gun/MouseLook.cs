using UnityEngine;

namespace EZCameraShake
{
    [RequireComponent(typeof(CameraShaker))]
    public class MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 200f;
        public Transform playerBody;

        private float xRotation = 0f;
        private Vector3 initialLocalPosition;
        private CameraShaker shaker;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            shaker = GetComponent<CameraShaker>();
            initialLocalPosition = transform.localPosition;
        }

        void LateUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            // Apply camera rotation for look
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

            // Maintain the camera's base position (prevent going down)
            shaker.RestPositionOffset = initialLocalPosition;
        }
    }
}
