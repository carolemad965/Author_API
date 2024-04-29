using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Author_API.DTO;
using Author_API.Repository;
using Author_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Author_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository newsRepository;
        public NewsController(INewsRepository _newsRepository)
        {
            newsRepository = _newsRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<News> news = newsRepository.GetAll();
            if (news == null)
            {
                return Ok(new Response()
                {
                    IsPass = false,
                    Message = "No Data Available"
                });

            }
            return Ok(new Response()
            {
                IsPass = true,
                Message =news
            });
        }
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {

            News news = newsRepository.GetById(id);
            if (news == null)
            {
                return Ok(new Response()
                {
                    IsPass = false,
                    Message = "Id Not Founds"
                });
            }

            return Ok(new Response()
            {
                IsPass = true,
                Message = news
            });
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(News_BaiscDataDTO news)
        {
            if (ModelState.IsValid == true)
            {
                News newNews = new News
                {
                    Title = news.Title,
                    Content=news.Content,
                    Image=news.Image,
                    CreationDate=news.CreationDate,
                    PublicationDate = news.PublicationDate,
                    AuthorId= news.AuthorId
                    
                };
                
                newsRepository.Add(newNews);
                newsRepository.Save();
                int newNewsId = newNews.Id;
                return Ok(new Response()
                {
                    IsPass = true,
                    Message = new
                    {
                        News = newNews,
                        NewsId = newNewsId
                    }
                });
            }
            return Ok(new Response()
            {
                IsPass = false,
                Message = ModelState
            });
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, News_BaiscDataDTO news)
        {

            News updatedNews = new News
            {

                Title = news.Title,
                Content = news.Content,
                Image = news.Image,
                CreationDate = news.CreationDate,
                PublicationDate = news.PublicationDate,
                AuthorId = news.AuthorId
            };

            bool isUpdated = newsRepository.Update(id, updatedNews);
            newsRepository.Save();

            int updatedNewsId = updatedNews.Id;

            if (isUpdated)
            {
                return Ok(new Response()
                {
                    IsPass = true,
                    Message = new
                    {
                        Author = updatedNews,
                        AuthorId = updatedNewsId
                    }
                });
            }

            return Ok(new Response()
            {
                IsPass = false,
                Message = "Faild to update"
            });
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                newsRepository.Delete(id);
                newsRepository.Save();
                return Ok(new Response()
                {
                    IsPass = true,
                    Message = "Removed Successfully"
                });
            }
            catch (Exception ex)
            {
                return Ok(new Response()
                {
                    IsPass = true,
                    Message = ex.Message
                });

            }

        }

    }
}
