using Author_API.Models;

namespace Author_API.Repository
{
    public interface INewsRepository
    {
        List<News> GetAll();
        News GetById(int id);
        void Add(News news);
        bool Update(int id, News news);
        bool Delete(int id);
        void Save();
    }
}