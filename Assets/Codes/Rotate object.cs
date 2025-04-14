using UnityEngine;

public class RotateAndFloat : MonoBehaviour
{
    public float rotationSpeed = 45f;         // Degrees per second
    public float floatAmplitude = 0.5f;       // How much it moves up and down
    public float floatFrequency = 1f;         // How fast it moves up and down

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotate on Y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Float up and down
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
