using System.Threading.Tasks;

namespace BusinessAssociates.EventSourcing
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}