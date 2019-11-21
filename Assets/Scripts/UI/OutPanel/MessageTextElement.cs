using System.Text;
using Assets.Scripts.UI.Elements;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.OutPanel
{
    public class MessageTextElement : MonoBehaviour
    {
        [SerializeField] private MultiImage messageImage;
        [SerializeField] private CanvasGroup nameCanvasGroup;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] [Min(0)] private int maxLineLength;

        public MultiImage MessageImage => messageImage;
        public TextMeshProUGUI NameText => nameText;
        public CanvasGroup NameCanvasGroup => nameCanvasGroup;

        public void Initialize(string name, string message)
        {
            nameText.text = name;
            messageText.text = PrepareMessageText(message);
            timeText.text = System.DateTime.Now.ToLongTimeString();
        }

        private string PrepareMessageText(string message)
        {
            var splitMessage = message.Split(' ','\n');
            var mergeMessage = new StringBuilder();
            var mergeLine = new StringBuilder();

            for (var i = 0; i < splitMessage.Length; i++)
            {
                var wordLength = splitMessage[i].Length;
                if (wordLength > maxLineLength)
                {
                    if (i != 0)
                    {
                        mergeMessage.Append(mergeLine.Append("<br>").ToString());
                        mergeLine.Clear();
                    }

                    var count = Mathf.Ceil(wordLength / (float) maxLineLength);
                    for (var j = 0; j < count; j++)
                    {
                        var substring = splitMessage[i].Substring(j * maxLineLength, Mathf.Min(maxLineLength, wordLength - j*maxLineLength));

                        if (j < count - 1) { mergeMessage.Append(substring).Append("<br>"); }
                        else
                        {
                            mergeLine.Append(substring);
                        }
                    }
                    continue;
                }

                if (mergeLine.Length + wordLength > maxLineLength)
                {
                    mergeMessage.Append(mergeLine.Append("<br>").ToString());
                    mergeLine = new StringBuilder(splitMessage[i]).Append(" ");
                    continue;
                }

                mergeLine.Append(splitMessage[i]).Append(" ");
            }

            mergeMessage.Append(mergeLine);

            mergeLine.Clear();
            return mergeMessage.ToString();
        }

    }
}
