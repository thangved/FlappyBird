using UnityEngine;

namespace Scripts
{
    public class Sprite : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private int spriteIndex;

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
}
