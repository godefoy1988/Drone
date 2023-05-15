using System.ComponentModel.DataAnnotations;

namespace Drones.ViewModel
{
    public class MedicationViewModel
    {
        [RegularExpression(@"^[a-zA-Z0-9_-]*$",ErrorMessage = "Allowed only letters, numbers, ‘-‘, ‘_’")]
        public string Name { get; set; }
        public double Weight { get; set; }
        [RegularExpression(@"^[A-Z0-9_]*$", ErrorMessage = "Allowed only upper case letters, underscore and numbers")]
        public string Code { get; set; }        
        public IFormFile? File { get; set; }
        public string? PathImage { get; set; }
        public string? ImageName { get; set; }
    }
}
