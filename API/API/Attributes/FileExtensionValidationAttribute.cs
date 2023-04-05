using System.ComponentModel.DataAnnotations;

namespace API.Attributes
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        private readonly string[] validTypes;
        public FileExtensionAttribute(string[] validTypes)
        {
            this.validTypes = validTypes;
        }

        public FileExtensionAttribute(FileType fileType)
        {
            if (fileType == FileType.Image)
            {
                validTypes = new[] { "image/png", "image/jpeg" };
            }
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formfile = value as IFormFile;
            if (formfile != null)
            {
                if (!validTypes.Contains(formfile.ContentType))
                {
                    return new ValidationResult($"Los tipos válidos son + {string.Join(",", validTypes)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}