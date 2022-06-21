using UnityEngine;

public class Pipes : MonoBehaviour
{
    private float leftEdge;
    private Vector3 bulletDirection;
    private bool hasBullet;

    public float speed = 1f;
    public bool useBullet;
    public GameObject bullet;

    private void Awake()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
        hasBullet = Random.Range(0f, 100f) > 50f;
        if (!hasBullet)
            return;
        bulletDirection = new Vector3(transform.position.x, transform.position.y - 2f, 0);
        bullet =  Instantiate(bullet, bulletDirection, Quaternion.identity);
    }
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
        bulletDirection.x = transform.position.x;

        if (!useBullet || !hasBullet)
            return;
        if (transform.position.x < 1f)
        {
            bulletDirection += Vector3.up * Time.deltaTime * 10;
        }
        bullet.transform.position = bulletDirection;
    }

    private void OnDestroy()
    {
        if (!hasBullet)
            return;
        Destroy(bullet.gameObject);
    }

    public bool GetHasBullet()
    {
        return hasBullet;
    }
}
