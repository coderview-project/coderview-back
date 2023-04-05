using System.ComponentModel.DataAnnotations;

namespace API.Attributes
{
    public class FileWeightAttribute : ValidationAttribute
    {
        private readonly double fileWeightKb;

        public FileWeightAttribute(double fileWeightKb)
        {
            this.fileWeightKb = fileWeightKb;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formfile = value as IFormFile;
            if (formfile != null)
            {
                if (formfile.Length / 1024 > fileWeightKb)
                {
                    return new ValidationResult($"El peso del archivo que enviaste es {formfile.Length / 1024}Kb y supera el máximo permitido de {fileWeightKb}Kb");
                }
            }
            return ValidationResult.Success;
        }
    }
}
