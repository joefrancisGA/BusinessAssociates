namespace BusinessAssociates.EventSourcing
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}