using System.Threading.Tasks;

namespace BusinessAssociates.EventSourcing
{
    public interface ISubscription
    {
        Task Project(object @event);
    }
}