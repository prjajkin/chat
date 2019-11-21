using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class CanvasGroupUtility 
    {
        public static void Show(this CanvasGroup canvasGroup, bool changeInteractable = true)
        {
            canvasGroup.alpha = 1;
            if (!changeInteractable) return;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public static void Hide(this CanvasGroup canvasGroup, bool changeInteractable = true)
        {
            canvasGroup.alpha = 0;
            if (!changeInteractable) return;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
