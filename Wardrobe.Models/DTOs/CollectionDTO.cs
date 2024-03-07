using System.ComponentModel.DataAnnotations;
using Wardrobe.Models.DTOs;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class GendersValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var selectedGenders = validationContext.ObjectInstance.GetType().GetProperty("SelectedGenders")?.GetValue(validationContext.ObjectInstance) as List<GenderDTO>;

        if (selectedGenders != null && selectedGenders.Count > 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}

namespace Wardrobe.Models.DTOs
{
    public class CollectionDTO
    {
        public int CollectionId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<GenderDTO> Genders { get; set; }
        [Required(ErrorMessage = "Please provide at least one gender")]
        [GendersValidation(ErrorMessage = "Please provide at least one gender")]
        public List<GenderDTO> SelectedGenders { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
