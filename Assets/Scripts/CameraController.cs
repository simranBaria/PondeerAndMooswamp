using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed, zoomSpeed, minVerticalAngle, maxVerticalAngle, minZoom, maxZoom;
    public Camera cameraObject;
    Transform cameraTransform, zoomTransform;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        zoomTransform = cameraObject.GetComponent<Transform>();

    }

    void Update()
    {

    }

    public void RotateUp ()
    {
        RotateCamera(-rotationSpeed, 0);
    }

    public void RotateDown ()
    {
        RotateCamera(rotationSpeed, 0);
    }

    public void RotateLeft ()
    {
        RotateCamera(0, rotationSpeed);
    }

    public void RotateRight ()
    {
        RotateCamera(0, -rotationSpeed);
    }

    public void ZoomIn()
    {
        ZoomCamera(-zoomSpeed);
    }

    public void ZoomOut()
    {
        ZoomCamera(zoomSpeed);
    }

    void RotateCamera(float verticalRotation, float horizontalRotation)
    {
        // Rotate the camera
        Vector3 rotation = transform.rotation.eulerAngles + new Vector3(verticalRotation, horizontalRotation, 0f);

        // Clamp the vertical angle
        rotation.x = ClampAngle(rotation.x, minVerticalAngle, maxVerticalAngle);

        cameraTransform.eulerAngles = rotation;
    }

    float ClampAngle(float angle, float minAngle, float maxAngle)
    {
        // Clamp between a negative and positive angle to use for eulers
        if (angle < 0) angle = 360 + angle;
        if (angle > 180) return Mathf.Max(angle, 360 + minAngle);
        return Mathf.Min(angle, maxAngle);
    }

    void ZoomCamera(float zoom)
    {
        // Zoom the camera
        Vector3 zoomPosition = zoomTransform.position + new Vector3(0, 0, zoom);

        // Clamp between min and max zoom
        zoomPosition.z = Mathf.Clamp(zoomPosition.z, minZoom, maxZoom);

        zoomTransform.position = zoomPosition;
    }
}
