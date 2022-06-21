using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    public float gravity = -9.8f;
    public float strength = 5f;

    public AudioSource hit;
    public AudioSource point;
    public AudioSource wing;

    private void Awake()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        bool falling = true;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            falling = false;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                falling = false;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        if (falling)
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
        }

        if (!falling)
        {
            wing.Play();
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 45);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            hit.Play();
            FindObjectOfType<GameManager>().GameOver();
        }

        if (collision.tag == "Scoring")
        {
            point.Play();
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
        transform.position = direction;
    }

}
