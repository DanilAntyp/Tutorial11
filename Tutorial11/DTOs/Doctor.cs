using System.ComponentModel.DataAnnotations;

namespace Tutorial11.DTOs;

public class Doctor
{
    [Key] 
    public int IdDoctor { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public string Email { get; set; }
    
}