using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AutoRotator : MonoBehaviour
{
    public float rotationSpeed = 20f;  // Positive = clockwise, Negative = counterclockwise
    public bool rotateLeftToRight = true;  // Toggle to reverse direction

    private bool isGrabbed = false;

    private void Update()
    {
        if (!isGrabbed)
        {
            float direction = rotateLeftToRight ? 1f : -1f;
            transform.Rotate(Vector3.up * rotationSpeed * direction * Time.deltaTime, Space.World);
        }
    }

    public void OnGrab()
    {
        isGrabbed = true;
    }

    public void OnRelease()
    {
        isGrabbed = false;
    }
}
