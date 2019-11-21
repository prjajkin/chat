using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Configs;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.OutPanel
{
    public class MessageOutPanel : MonoBehaviour, IMessageBuilder
    {
        [SerializeField] private GameObject messageFramePrefab;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform layoutTransform;

        private List<MessageFrame> messageFrames= new List<MessageFrame>();

        public void BuildMessage(AuthorDataWrapper authorData, string message)
        {
            if (messageFrames != null && messageFrames.Count>0 && messageFrames.Last().AuthorData == authorData)
            {
                messageFrames.Last().AddMessage(message);
                return;
            }

            var messageFrame = PrefabUtility.InstantiatePrefab<MessageFrame>(messageFramePrefab, layoutTransform);
            messageFrame.Initialize(authorData);
            messageFrame.AddMessage(message);
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutTransform);
            scrollRect.verticalScrollbar.value = 0;
            messageFrames.Add(messageFrame);
            messageFrame.EmptyEvent.AddListener(()=>
            {
                messageFrames.Remove(messageFrame);
                Destroy(messageFrame);
            });
            Debug.Log("SendMessage");
        }


        public void ShowRemoveButtons(bool isShow)
        {
            messageFrames?.ForEach(x=>x.ShowRemoveButtons(isShow));
        }
    }
}
