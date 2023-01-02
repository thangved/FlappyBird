using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;

    public float gravity = -9.8f;
    public float strength = 5f;

    public AudioSource hit;
    public AudioSource point;
    public AudioSource wing;

    private void Awake()
    {
        _direction = Vector3.zero;
    }

    private void Update()
    {
        bool falling = true;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _direction = Vector3.up * strength;
            falling = false;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _direction = Vector3.up * strength;
                falling = false;
            }
        }

        _direction.y += gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;

        if (falling)
        {
            var rotation = transform.rotation;
            Quaternion target = Quaternion.Euler(rotation.x, rotation.y, -90);
            rotation = Quaternion.Slerp(rotation, target, Time.deltaTime);
            transform.rotation = rotation;
        }
        else 
        {
            wing.Play();
            var rotation = transform.rotation;
            rotation = Quaternion.Euler(rotation.x, rotation.y, 45);
            transform.rotation = rotation;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            hit.Play();
            FindObjectOfType<GameManager>().GameOver();
        }

        if (!collision.CompareTag("Scoring")) return;
        point.Play();
        FindObjectOfType<GameManager>().IncreaseScore();
    }

    private void OnEnable()
    {
        _direction = Vector3.zero;
        transform.position = _direction;
    }

}