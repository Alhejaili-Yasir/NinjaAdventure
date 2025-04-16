using UnityEngine;

public class MoveOnXAxis : MonoBehaviour
{
    public float speed = 2f;
    public float minX = -3f;
    public float maxX = 4f;

    private float range;

    void Start()
    {
        range = maxX - minX;
    }

    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(minX + pingPong, transform.position.y, transform.position.z);
    }
}
