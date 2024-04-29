using Author_API.Models;

namespace Author_API.Repository
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetById(int id);
        void Add(Author author);
        bool Update(int id, Author author);
        bool Delete(int id);
        Author GetByName(string name);
        void Save();
    }
}