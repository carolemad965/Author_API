using Author_API.Models;

namespace Author_API.Repository
{
   
    public class NewsRepository: INewsRepository
    {
        private readonly Context context;
        public NewsRepository(Context _context)
        {
            context = _context;
        }
        public void Add(News news)
        {
            context.News.Add(news);
        }
        public News GetById(int id)
        {
            News? news = context.News.FirstOrDefault(newsDB => newsDB.Id == id);

            return news;
        }
       
        public List<News> GetAll()
        {
            List<News> news = context.News.ToList();
            return news;
        }
        public bool Update(int id, News news)
        {
            
            bool IsValid = true;
            News NewsFromDb = GetById(id);
            if (NewsFromDb == null)
            {
                IsValid = false;
            }
            

            if (IsValid)
            {
                NewsFromDb.Title=news.Title;
                NewsFromDb.Content=news.Content;
                NewsFromDb.Image=news.Image;
                NewsFromDb.CreationDate = news.CreationDate;
                NewsFromDb.PublicationDate=news.PublicationDate;
                NewsFromDb.AuthorId=news.AuthorId;
                context.News.Update(news);
            }
            return IsValid;
        }
        public bool Delete(int id)
        {
            News NewsFromDB = GetById(id);
            if (NewsFromDB != null)
            {
                context.Remove(NewsFromDB);
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
