using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class CreateBookViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        public string SelectedAuthorValue { get; set; } = string.Empty;

        public string? NewAuthorName { get; set; }

        public List<int> SelectedCategoryIds { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SelectedAuthorValue == "__add_new_author__" && string.IsNullOrWhiteSpace(NewAuthorName))
            {
                yield return new ValidationResult(
                    "New author name is required.",
                    new[] { nameof(NewAuthorName) });
            }

            if (SelectedCategoryIds.Count == 0)
            {
                yield return new ValidationResult(
                    "At least one category is required.",
                    new[] { nameof(SelectedCategoryIds) });
            }
        }
    }
}
