using System.ComponentModel.DataAnnotations;

namespace Drones.Validations
{
    public sealed class OneOfThemValidation : ValidationAttribute
    {
        public string Values { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valuesSeparatedByComma = Values.Split(',').Select(v => v.ToLower());
            var valueToLower = value.ToString().ToLower();
            if (valuesSeparatedByComma.Contains(valueToLower))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"Please choose a valid value eg.({Values})");
            }
        }
    }
}
