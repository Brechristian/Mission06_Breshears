using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Breshears.Models
{
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieId {  get; set; } //if only a get, then a read only variable



        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public string Category {  get; set; }


        [Required (ErrorMessage = "Must have a Title")]
        public string Title { get; set; }


        [Required]
        [Range(1880, 9999, ErrorMessage = "Must be a valid year")]
        public int Year {  get; set; }


        [Required (ErrorMessage = "Must include the director's name(s)")]
        public string? Director { get; set; }


        [Required]
        public string Rating { get; set; }


        [Required(ErrorMessage = "Must include if edited.")]
        public bool Edited { get; set; }

        public string? Lentto { get; set; }   

        
        [Required (ErrorMessage = "Must tell if copied to Plex")]
        public bool CopiedToPlex { get; set; }

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
