using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace test_CSharp.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Candidate
    {
        [Key]
        public int IdCandidate { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(150)]
        [Required]
        public string Surname { get; set; } = string.Empty;

        [MaxLength(250)]
        [Required]
        public string Email { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }

    }
}
