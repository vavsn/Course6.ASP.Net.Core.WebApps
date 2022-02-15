namespace TimeSheets.BL.Services
{
    public interface IPersonService<T> where T : class
    {
        T GetById(int id);
        T GetByName(string name);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}