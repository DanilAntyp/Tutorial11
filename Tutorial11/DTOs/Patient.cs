using System.ComponentModel.DataAnnotations;

namespace Tutorial11.DTOs;

public class Patient
{
    
    [Key] 
    public int IdPatient { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }

    public DateTime Birthdate { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
    
}