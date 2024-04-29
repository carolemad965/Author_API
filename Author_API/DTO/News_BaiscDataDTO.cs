using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Author_API.Attributes;

namespace Author_API.DTO
{
    public class News_BaiscDataDTO
    {
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
    }
}
