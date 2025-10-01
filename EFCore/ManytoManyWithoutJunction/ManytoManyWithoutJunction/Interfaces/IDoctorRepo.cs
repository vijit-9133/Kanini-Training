namespace ManytoManyWithoutJunction.Interfaces
{
    public interface IDoctorRepo<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T>Add(T entity);
    }
}
