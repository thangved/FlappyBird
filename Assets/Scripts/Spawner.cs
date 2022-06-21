using UnityEngine;

namespace Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject prefab;
        public float spawnRate = 1f;
        public float minHeight = -1f;
        public float maxHeight = 1f;

        private bool useBullet = true;
        private int bullets;

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
            var position = transform.position;
            return new Vector3(position.x, Random.Range(minHeight, maxHeight), position.y);
        }

        public int GetBulletsCount()
        {
            return bullets;
        }

    }
}
