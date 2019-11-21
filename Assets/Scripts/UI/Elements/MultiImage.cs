using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Elements
{
    public class MultiImage : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite defaultSprite;
        [SerializeField] private List<Sprite> sprites;

        public void SetDefaultSprite()
        {
            image.sprite = defaultSprite;
        }

        public void SetSprite(int number)
        {
            if (number >= sprites.Count)
            {
                Debug.LogError("Проверти спрайты для компонента MultiImage.");
                return;
            }
            image.sprite = sprites[number];
        }
    }
}
