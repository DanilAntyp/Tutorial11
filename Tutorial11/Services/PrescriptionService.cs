using Tutorial11.DTOs;
using Tutorial11.Exceptions;

namespace Tutorial11.Services;

public class PrescriptionService : IPrescriptionService
{
    private IDbService _dbService;

    public PrescriptionService(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    public async Task<int> AddPrescription(PrescriptionDTO prescriptionDto)
    {
        if (prescriptionDto.DueDate < prescriptionDto.Date)
            throw new BadRequest("Due date is before issue Date");
        
        foreach (var medication in prescriptionDto.Medicaments)
        {
            if (!await _dbService.MedicationExists(medication.IdMedicament))
                throw new NotFound("No medication");
        }
        
        if (!await _dbService.PatientExists(prescriptionDto.Patient.IdPatient))
        {
            await _dbService.AddPatient(prescriptionDto.Patient);
        }
        
        return await _dbService.AddPrescription(prescriptionDto);
    }
}