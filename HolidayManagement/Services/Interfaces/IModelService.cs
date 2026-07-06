namespace HolidayManagement.Services.Interfaces
{
    public interface IModelService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(T model);
        Task Delete(Guid id);
        Task Update(T model, Guid id);
    }
}
