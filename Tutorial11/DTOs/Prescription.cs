using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial11.DTOs;

public class Prescription
{
    [Key] 
    public int IdPrescription { get; set; }

    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [ForeignKey(nameof(Patient))] 
    public int IdPatient { get; set; }
    
    [ForeignKey(nameof(Doctor))] 
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}