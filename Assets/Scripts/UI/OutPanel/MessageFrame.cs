using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Configs;
using Assets.Scripts.Utility;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.OutPanel
{
    public class MessageFrame : MonoBehaviour
    {
        [SerializeField] private GameObject myMessageElementPrefab;
        [SerializeField] private GameObject messageElementPrefab;
        [SerializeField] private RectTransform layouTransform;

        public AuthorDataWrapper AuthorData  { get; private set; }
        public UnityEvent EmptyEvent;
        private List<MessageElement> elements;
        
        public void Initialize(AuthorDataWrapper authorDataWrapper)
        {
            elements = new List<MessageElement>();
            AuthorData = authorDataWrapper;
        }

        public void AddMessage(string message)
        {
            if (elements != null && elements.Count > 0)
            {
                elements.Last().SetVisualState(VisualMessageElementState.NotLast);
            }

            var messageElement = PrefabUtility.InstantiatePrefab<MessageElement>(
                AuthorData.IsUser ? myMessageElementPrefab : messageElementPrefab, transform);
            messageElement.Initialize(AuthorData.Data, message);
            elements.Add(messageElement);

            LayoutRebuilder.ForceRebuildLayoutImmediate(layouTransform);

            messageElement.RemoveButton.OnClickAsObservable().Subscribe(_ =>
            {
                elements.Remove(messageElement);
                Destroy(messageElement.gameObject);
                if (elements.Count < 1)
                {
                    EmptyEvent?.Invoke();
                    EmptyEvent=null;
                    Destroy(this.gameObject);
                }
            }).AddTo(messageElement.gameObject);
            
        }

        public void ShowRemoveButtons(bool isShow)
        {
            if (!AuthorData.IsUser) return;
            elements?.ForEach(x=>x.SetRemoveButtonState(isShow));
        }
    }
}
