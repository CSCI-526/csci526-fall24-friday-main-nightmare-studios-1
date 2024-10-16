using UnityEngine;

public class MoveContinuously : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f; // Speed of the square
    public float boundary = 0.5f; // Horizontal boundary for movement
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, boundary * 2) - boundary + startPosition.x, startPosition.y, startPosition.z);
    }
}
