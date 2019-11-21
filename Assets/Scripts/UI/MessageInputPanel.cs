using Assets.Scripts.Utility;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MessageInputPanel : MonoBehaviour
    {
        [SerializeField] private Button sendButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private CanvasGroup inputFieldCanvasGroup;
        [SerializeField] private Button removeButton;
        [SerializeField] private CanvasGroup removeButtonCanvasGroup;
        [SerializeField] private Button confirmButton;

        private void Awake()
        {
            sendButton.OnClickAsObservable().Subscribe(_ =>
            {
                if (string.IsNullOrEmpty(inputField.text)) return;
                ChatManager.Instance.SendChatMessage(inputField.text);
                inputField.text = "";
            });
            removeButton.OnClickAsObservable().Subscribe(_ =>
            {
                confirmButton.gameObject.SetActive(true);
                sendButton.gameObject.SetActive(false);
                removeButtonCanvasGroup.Hide();
                inputFieldCanvasGroup.Hide();
                ChatManager.Instance.MessageOutPanel.ShowRemoveButtons(true);
            });
            confirmButton.OnClickAsObservable().Subscribe(_ =>
            {
                confirmButton.gameObject.SetActive(false);
                sendButton.gameObject.SetActive(true);
                removeButtonCanvasGroup.Show();
                inputFieldCanvasGroup.Show();
                ChatManager.Instance.MessageOutPanel.ShowRemoveButtons(false);
            });
        }
    }
}
