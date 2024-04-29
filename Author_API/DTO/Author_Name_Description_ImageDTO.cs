using System.ComponentModel.DataAnnotations;

namespace Author_API.DTO
{
    public class Author_Name_Description_ImageDTO
    {
        

        [Required(ErrorMessage = "Author's name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Author's name must be between 3 and 20 characters.")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
