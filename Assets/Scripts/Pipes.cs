using UnityEngine;
using Random = UnityEngine.Random;

public class Pipes : MonoBehaviour
{
    private float _leftEdge;

    public float speed = 1f;

    private void Awake()
    {
        if (Camera.main != null) _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    void Update()
    {
        transform.position += Vector3.left * (Time.deltaTime * speed);

        if (transform.position.x < _leftEdge)
        {
            Destroy(gameObject);
        }
    }

}