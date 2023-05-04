using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        Pipes pipes = Instantiate(prefab, RandomPosition(), Quaternion.identity).GetComponent<Pipes>();
    }

    private Vector3 RandomPosition()
    {
        var position = transform.position;
        return new Vector3(position.x, Random.Range(minHeight, maxHeight), position.y);
    }

}