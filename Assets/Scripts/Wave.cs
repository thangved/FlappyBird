using UnityEngine;

public class Wave : MonoBehaviour
{
    public float strength = 3f;
    public float maxDistance = 1f;

    private bool _downing;
    private Vector3 _direction;

    private void Awake()
    {
        _direction = Vector3.zero;
    }

    private void Update()
    {
        UpdateDowning();
        UpdateDirection();
    }

    private void UpdateDowning()
    {
        if (_direction.y > maxDistance / 2)
        {
            _downing = true;
        }
        if (_direction.y < - maxDistance / 2)
        {
            _downing = false;
        }
    }

    private void UpdateDirection()
    {
        if (_downing)
        {
            _direction += Vector3.down * (strength * Time.deltaTime);
        }
        else
        {
            _direction += Vector3.up * (strength * Time.deltaTime);
        }

        transform.position = _direction;
    }
}