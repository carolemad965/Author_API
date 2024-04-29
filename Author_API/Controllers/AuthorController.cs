using Author_API.Models;
using Author_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Author_API.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Author_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorController(IAuthorRepository _authorRepository) {
        
            authorRepository = _authorRepository;
        
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetAll()
        {
            List<Author> authors = authorRepository.GetAll();
            if (authors == null)
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
                Message = authors
            });
        }
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string name)
        {
            Author author = authorRepository.GetByName(name);

            if (author == null)
            {
              
                return Ok(new Response()
                {
                    IsPass = false,
                    Message = "Name Not Founds"
                });
            }

            return Ok(new Response()
            {
                IsPass = true,
                Message = author
            });
        }
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id) { 
        
            Author author=authorRepository.GetById(id);
            if(author == null)
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
                Message = author
            });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(Author_Id_Name_Description_ImageDTO author)
        {
            if (ModelState.IsValid == true)
            {
                Author newAuthor = new Author
                {
                    Id = author.Id,
                    Name = author.Name,
                    Description= author.Description,
                    Image=author.Image
                };
                authorRepository.Add(newAuthor);
                authorRepository.Save();
                int newAuthorId = newAuthor.Id;
                return Ok(new Response()
                {
                    IsPass = true,
                    Message = new
                    {
                        Author = newAuthor,
                        AuthorId = newAuthorId
                    }
                }) ;
            }
            return Ok(new Response()
            {
                IsPass = false,
                Message =ModelState
            });
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id,Author_Name_Description_ImageDTO author)
        {

                    Author updatedAuthor = new Author
                    {
                        
                        Name = author.Name,
                        Description = author.Description,
                        Image = author.Image
                    };

                    bool isUpdated = authorRepository.Update(id, updatedAuthor);
                    authorRepository.Save();

                    int updatedAuthorId = updatedAuthor.Id;

                    if (isUpdated)
                    {
                        return Ok(new Response()
                        {
                            IsPass = true,
                            Message = new
                            {
                                Author = updatedAuthor,
                                AuthorId = updatedAuthorId
                            }
                        });
                    }


                


            
            
            return Ok(new Response()
            {
                IsPass = false,
                Message= "Faild to update"
            });
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                authorRepository.Delete(id);
                authorRepository.Save();
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
