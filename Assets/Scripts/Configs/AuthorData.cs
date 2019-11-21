using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "AuthorData", menuName = "Configs/Create Data Data", order = 51)]
    public class AuthorData : ScriptableObject
    {
        [SerializeField] private Sprite avatarSprite;
        [SerializeField] private string writerName = "Unnamed";

        public Sprite AvatarSprite => avatarSprite;
        public string WriterName => writerName;
    }
}
