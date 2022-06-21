using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private bool useBullet = true;
    private int bullets = 0;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        bullets = 0;
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        Pipes pipes = Instantiate(prefab, RandomPosition(), Quaternion.identity).GetComponent<Pipes>();

        pipes.useBullet = useBullet;
        if (!pipes.GetHasBullet() || !useBullet)
            return;

        bullets++;

    }

    public void SetUseBullet(bool use)
    {
        useBullet = !useBullet;
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.y);
    }

    public int GetBulletsCount()
    {
        return bullets;
    }

}
