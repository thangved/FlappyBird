using UnityEngine;
using Random = UnityEngine.Random;

public class Pipes : MonoBehaviour
{
    private float _leftEdge;
    private Vector3 _bulletDirection;
    private bool _hasBullet;

    public float speed = 1f;
    public bool useBullet;
    public GameObject bullet;

    private void Awake()
    {
        if (Camera.main != null) _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        _hasBullet = Random.Range(0f, 100f) > 50f;
        if (!_hasBullet)
            return;
        var position = transform.position;
        _bulletDirection = new Vector3(position.x, position.y - 2f, 0);
        bullet =  Instantiate(bullet, _bulletDirection, Quaternion.identity);
    }
    void Update()
    {
        transform.position += Vector3.left * (Time.deltaTime * speed);
        
        if (transform.position.x < _leftEdge)
        {
            Destroy(gameObject);
        }
        _bulletDirection.x = transform.position.x;

        if (!useBullet || !_hasBullet)
            return;
        if (transform.position.x < .5f)
        {
            _bulletDirection += Vector3.up * (Time.deltaTime * 10);
        }
        bullet.transform.position = _bulletDirection;
    }

    private void OnDestroy()
    {
        if (!_hasBullet)
            return;
        Destroy(bullet.gameObject);
    }

    public bool GetHasBullet()
    {
        return _hasBullet;
    }

}