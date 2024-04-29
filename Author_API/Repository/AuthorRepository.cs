using Author_API.Models;

namespace Author_API.Repository
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly Context context;
       public AuthorRepository(Context _context)
        {
            context = _context;
        }
        public void Add(Author author)
        {
            context.Authors.Add(author);
        }
        public Author GetById(int id)
        {
            Author? author = context.Authors.FirstOrDefault(authorDB => authorDB.Id == id);

            return author;
        }
        public Author GetByName(string name)
        {
            Author? author = context.Authors.FirstOrDefault(authorDB => authorDB.Name == name);
            return author;

        }
        public List<Author> GetAll()
        {
            List<Author> authors = context.Authors.ToList();
            return authors;
        }
        public bool Update(int id, Author author)
        {
            
            bool IsValid = true;
            Author AuthorFromDb = GetById(id);
            if (AuthorFromDb == null)
            {
                IsValid = false;
            }
           

            if (IsValid)
            {
               
                AuthorFromDb.Name = author.Name;
                AuthorFromDb.Description = author.Description;
                AuthorFromDb.Image = author.Image;  
                context.Authors.Update(AuthorFromDb);
                
            }
            return IsValid;
        }
        public bool Delete(int id)
        {
            Author AuthorFromDB = GetById(id);
            if (AuthorFromDB != null)
            {
                context.Remove(AuthorFromDB);
                return true;
            }
            return false;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
