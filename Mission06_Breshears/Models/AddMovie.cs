using System.ComponentModel.DataAnnotations;

namespace Mission06_Breshears.Models
{
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieID {  get; set; } //if only a get, then a read only variable
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1900, 9999, ErrorMessage = "The Year must be between 1900 and 9999.")]
        public int Year {  get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? Lentto { get; set; }
        [StringLength(25, ErrorMessage = "The Notes field cannot exceed 25 characters.")]
        public string? Notes {  get; set; }
    }
}
//Include options for the following: MUST INCLUDE THESE
// Category (string)
// Title (string)
// Edited (yes/no aka true/false bool)
// Year (int)
// Directory (string)
// Rating (Category dropdown, G, PG, PG-13, R)

//The following are not required to be filled out:
// Edited (yes/no, true/false boolean)
// Lent To (string)
// Notes (string)
