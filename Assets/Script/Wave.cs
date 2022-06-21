using UnityEngine;

public class Wave : MonoBehaviour
{
    public float strength = 3f;
    public float maxDistance = 1f;

    private bool downing = false;
    private Vector3 direction;

    private void Awake()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        UpdatDowning();
        UpdateDirection();
    }

    private void UpdatDowning()
    {
        if (direction.y > maxDistance / 2)
        {
            downing = true;
        }
        if (direction.y < -maxDistance / 2)
        {
            downing = false;
        }
    }

    private void UpdateDirection()
    {
        if (downing)
        {
            direction += Vector3.down * strength * Time.deltaTime;
        }
        else
        {
            direction += Vector3.up * strength * Time.deltaTime;
        }

        transform.position = direction;
    }
}
