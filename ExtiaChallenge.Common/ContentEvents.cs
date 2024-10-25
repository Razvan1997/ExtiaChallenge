using Prism.Events;

namespace ExtiaChallenge.Common
{
    public class ContentEvents : PubSubEvent<(string Message, bool Flag, object data)>
    {
    }
}
