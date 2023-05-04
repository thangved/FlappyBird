using UnityEngine;

public class Sprite : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;

    public UnityEngine.Sprite[] sprites;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), .05f, .05f);
    }

    private void AnimateSprite()
    {
        _spriteIndex++;
        _spriteIndex %= sprites.Length;

        _spriteRenderer.sprite = sprites[_spriteIndex];
    }

}