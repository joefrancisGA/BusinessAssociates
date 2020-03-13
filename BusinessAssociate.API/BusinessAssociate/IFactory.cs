namespace BusinessAssociate.API.BusinessAssociate
{
    public interface IFactory<out T>
    {
        T Create();
    }
}