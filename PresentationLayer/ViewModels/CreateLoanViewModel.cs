using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class CreateLoanViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Book is required.")]
        public int BookId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Member is required.")]
        public int MemberId { get; set; }
    }
}
