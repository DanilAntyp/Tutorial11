using System.ComponentModel.DataAnnotations;

namespace Tutorial11.DTOs;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string? Description { get; set; }
    
    [MaxLength(100)]
    public string Type { get; set; }
}