using Author_API.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Author_API.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "News content is required.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Publication date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [ValidPublicationDate(ErrorMessage = "Publication date must be between today and a week from today.")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Creation date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        public string Image { get; set; } 

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        
        public Author Author { get; set; }

    }
}
