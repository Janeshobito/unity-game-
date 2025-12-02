using UnityEngine;

/// <summary>
/// Keeps the weapon perfectly stable relative to the camera,
/// unaffected by dash movement or camera shake,
/// but still rotates with the camera.
/// </summary>
[DisallowMultipleComponent]
public class WeaponStabilizer : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Offsets")]
    public Vector3 localPositionOffset = new Vector3(0f, -0.05f, 0.3f);
    public Vector3 localRotationOffset = Vector3.zero;

    [Header("Smoothing")]
    public float rotationSmoothSpeed = 20f;

    private void LateUpdate()
    {
        if (playerCamera == null) return;

        // Always attach gun position relative to camera directly (no smoothing)
        transform.position = playerCamera.transform.TransformPoint(localPositionOffset);

        // Smooth rotation only
        Quaternion targetRotation = playerCamera.transform.rotation * Quaternion.Euler(localRotationOffset);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothSpeed);
    }
}
