using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public enum MovieRating
    {
        G,
        PG,
        PG13,
        R
    }


    public class MovieApp
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }

        // Properties for movie form
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }

}

