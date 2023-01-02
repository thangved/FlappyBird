using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private bool _useBullet = true;
    private int _bullets;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        _bullets = 0;
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        Pipes pipes = Instantiate(prefab, RandomPosition(), Quaternion.identity).GetComponent<Pipes>();

        pipes.useBullet = _useBullet;
        if (!pipes.GetHasBullet() || !_useBullet)
            return;

        _bullets++;

    }

    public void SetUseBullet(bool use)
    {
        _useBullet = !_useBullet;
    }

    private Vector3 RandomPosition()
    {
        var position = transform.position;
        return new Vector3(position.x, Random.Range(minHeight, maxHeight), position.y);
    }

    public int GetBulletsCount()
    {
        return _bullets;
    }

}