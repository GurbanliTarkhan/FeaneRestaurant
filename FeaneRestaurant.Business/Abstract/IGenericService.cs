namespace FeaneRestaurant.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        void TRemove(T entity);
        void TUpdate(T entity);
        T TGetById(int id);
        List<T> TGetAll();
    }
}
