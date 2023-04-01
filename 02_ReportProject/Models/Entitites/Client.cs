using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace _02_ReportProject.Models.Entitites
{
    public class Client
    {
        [Key]
        public int ClID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string FirstName { get; set; } = null!;
        public string LasttName { get; set; } = null!;
        public string Email { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
    }
}
