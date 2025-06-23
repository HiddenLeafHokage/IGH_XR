using UnityEngine;

public class hover : MonoBehaviour
{
    public float hoverHeight = 0.1f;      // How far it floats up and down
    public float hoverSpeed = 2f;         // Speed of the hover motion
    public float rotationSpeed = 10f;     // Slow rotation for realism

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Hover effect (sinusoidal)
        float newY = startPos.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Optional: slow rotation
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
