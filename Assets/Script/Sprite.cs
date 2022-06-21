using UnityEngine;

public class Sprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;

    public UnityEngine.Sprite[] sprites;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), .15f, .15f);
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        spriteIndex %= sprites.Length;

        spriteRenderer.sprite = sprites[spriteIndex];
    }

}
