using System.ComponentModel.DataAnnotations;

namespace _02_ReportProject.Models.Entitites;

public class Case
{
    [Key]
    public int CaseID { get; set; }
    [Required]
    public int ClientID { get; set; }
    public Client Client { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Required]
    public DateTime Time { get; set; }
    [Required]
    public string Status { get; set; } = null!;
}
