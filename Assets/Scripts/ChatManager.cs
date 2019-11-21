using Assets.Scripts.Configs;
using Assets.Scripts.UI.OutPanel;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChatManager : MonoBehaviour
    {
        [SerializeField]private WritersSetting writersSetting;
        [SerializeField]private MessageOutPanel messageOutPanel;

        public MessageOutPanel MessageOutPanel => messageOutPanel;

        public static ChatManager Instance;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(Instance);
                Instance = this;
            }
        }

        public void SendChatMessage(string message)
        {
            messageOutPanel.BuildMessage(writersSetting.GetRandomAuthor(), message);
        }

    }
}
