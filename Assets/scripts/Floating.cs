using UnityEngine;

public class Floating : MonoBehaviour
{
    public float speed = 1.0f;
    public float amplitude = 0.5f; 
    private float initialY;  

    private void Start()
    {
        initialY = transform.position.y;
    }

    private void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * amplitude + initialY;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
