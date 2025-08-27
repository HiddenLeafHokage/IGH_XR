using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    Renderer rend;

    Vector3 lastPos;
    Vector3 velocity;
    Vector3 lastRot;
    Vector3 angularVelocity;

    public float MaxWobble = 0.03f;
    public float WobbleSpeed = 1.0f;
    public float Recovery = 1.0f;

    float wobbleAmountX;
    float wobbleAmountZ;
    float wobbleAmountToAddX;
    float wobbleAmountToAddZ;

    float pulse;
    float time = 0.0f;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        // Decrease wobble over time
        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * Recovery);
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * Recovery);

        // Make a sine wave of the decreasing wobble
        pulse = 2 * Mathf.PI * WobbleSpeed;
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

        // Send it to the shader
        rend.material.SetFloat("WobbleX", wobbleAmountX);
        rend.material.SetFloat("WobbleZ", wobbleAmountZ);

        // Velocity
        velocity = (lastPos - transform.position) / Time.deltaTime;
        angularVelocity = transform.rotation.eulerAngles - lastRot;

        // Add velocity to wobble
        wobbleAmountToAddX += velocity.x + (angularVelocity.y * MaxWobble);
        wobbleAmountToAddZ += velocity.z + (angularVelocity.x * MaxWobble);

        // Keep wobble within limits
        wobbleAmountToAddX = Mathf.Clamp(wobbleAmountToAddX, -MaxWobble, MaxWobble);
        wobbleAmountToAddZ = Mathf.Clamp(wobbleAmountToAddZ, -MaxWobble, MaxWobble);

        // Update last position and rotation
        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;
    }
}