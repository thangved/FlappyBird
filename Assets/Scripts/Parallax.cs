using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public float parallaxSpeed = 0.5f;
    
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _meshRenderer.material.mainTextureOffset -= Vector2.left * (parallaxSpeed * Time.deltaTime);
    }
}