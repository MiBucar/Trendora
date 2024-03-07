using System.ComponentModel.DataAnnotations;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class ColorsValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var selectedColors = validationContext.ObjectInstance.GetType().GetProperty("SelectedColors")?.GetValue(validationContext.ObjectInstance) as List<ColorDTO>;

        if (selectedColors != null && selectedColors.Count > 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class TagsValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var selectedTags = validationContext.ObjectInstance.GetType().GetProperty("SelectedTags")?.GetValue(validationContext.ObjectInstance) as List<TagDTO>;

        if (selectedTags != null && selectedTags.Count > 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}

namespace Wardrobe.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public Guid IdGuid { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please provide an image")]
        public byte[] ImageData { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        public CategoryDTO Category { get; set; }

        public List<TagDTO> Tags { get; set; }
        [Required(ErrorMessage = "Please select at least one tag")]
        [ColorsValidation(ErrorMessage = "Please select at least one tag")]
        public List<TagDTO> SelectedTags { get; set; }
        public List<ColorDTO> Colors { get; set; }
        [Required(ErrorMessage = "Please select at least one color")]
        [ColorsValidation(ErrorMessage = "Please select at least one color")]
        public List<ColorDTO> SelectedColors { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a gender")]
        public int GenderId { get; set; }

        public GenderDTO Gender { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
