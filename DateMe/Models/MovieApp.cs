using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDB.Models
{
    public class MovieApp
    {
        public enum MovieRating
        {
            G,
            PG,
            PG13,
            R
        }

        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please specify if the movie is edited")]
        public string? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please specify if the movie is copied to Plex")]
        public string? CopiedToPlex { get; set; }

        [MaxLength(75, ErrorMessage = "Notes cannot exceed 75 characters")]
        public string? Notes { get; set; }
    }
}
