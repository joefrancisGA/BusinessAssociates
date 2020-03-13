using System.Threading.Tasks;

namespace BusinessAssociates.EventSourcing
{
    public interface ICheckpointStore
    {
        Task<long?> GetCheckpoint();
        Task StoreCheckpoint(long? checkpoint);
    }
}