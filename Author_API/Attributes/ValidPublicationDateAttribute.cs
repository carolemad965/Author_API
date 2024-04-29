using System.ComponentModel.DataAnnotations;
namespace Author_API.Attributes
{
    public class ValidPublicationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var publicationDate = (DateTime)value;

            if (publicationDate < DateTime.Today || publicationDate > DateTime.Today.AddDays(7))
            {
                return new ValidationResult("Publication date must be between today and a week from today.");
            }

            return ValidationResult.Success;
        }
    }
}
