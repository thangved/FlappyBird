using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts
{
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
            if (Camera.main != null) leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
            hasBullet = Random.Range(0f, 100f) > 50f;
            if (!hasBullet)
                return;
            var position = transform.position;
            bulletDirection = new Vector3(position.x, position.y - 2f, 0);
            bullet =  Instantiate(bullet, bulletDirection, Quaternion.identity);
        }
        void Update()
        {
            transform.position += Vector3.left * (Time.deltaTime * speed);
        
            if (transform.position.x < leftEdge)
            {
                Destroy(gameObject);
            }
            bulletDirection.x = transform.position.x;

            if (!useBullet || !hasBullet)
                return;
            if (transform.position.x < .5f)
            {
                bulletDirection += Vector3.up * (Time.deltaTime * 10);
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
}
