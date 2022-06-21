using UnityEngine;

namespace Scripts
{
    public class Parallax : MonoBehaviour
    {
        private MeshRenderer meshRenderer;

        public float parallaxSpeed = 0.5f;
    
        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            meshRenderer.material.mainTextureOffset -= Vector2.left * (parallaxSpeed * Time.deltaTime);
        }
    }
}
