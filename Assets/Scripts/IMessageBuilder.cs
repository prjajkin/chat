using Assets.Scripts.Configs;

namespace Assets.Scripts
{
    public interface IMessageBuilder
    {
        void BuildMessage(AuthorDataWrapper authorData, string message);
    }
}
