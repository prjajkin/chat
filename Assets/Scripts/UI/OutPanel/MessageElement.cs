using System;
using Assets.Scripts.Configs;
using Assets.Scripts.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.OutPanel
{
    public class MessageElement : MonoBehaviour
    {
        [SerializeField] private MessageTextElement messageTextElement;
        [SerializeField] private CanvasGroup avatarCanvasGroup;
        [SerializeField] private Image avatarImage;
        [SerializeField] private Button removeButton;

        public Button RemoveButton => removeButton;

        public void Initialize(AuthorData data, string message)
        {
            avatarImage.sprite = data.AvatarSprite;
            messageTextElement.Initialize(data.WriterName, message);
            SetVisualState(VisualMessageElementState.Last);
            SetRemoveButtonState(false);
        }

        public void SetVisualState(VisualMessageElementState visualState)
        {
            switch (visualState)
            {
                case VisualMessageElementState.Last:
                    messageTextElement.NameCanvasGroup.Show();
                    messageTextElement.MessageImage.SetSprite(1);
                    avatarCanvasGroup.Show();
                    break;
                case VisualMessageElementState.NotLast:
                    messageTextElement.NameCanvasGroup.Hide();
                    messageTextElement.MessageImage.SetSprite(0);
                    avatarCanvasGroup.Hide();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(visualState), visualState, null);
            }
        }

        public void SetRemoveButtonState(bool isShow)
        {
            removeButton.gameObject.SetActive(isShow);
        }
    }

    public enum VisualMessageElementState
    {
        Last=0,
        NotLast =1
    }
}
