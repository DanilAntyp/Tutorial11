using Tutorial11.DTOs;
using Tutorial11.Exceptions;

namespace Tutorial11.Services;

public class PatientService: IPatientService
{
    private IDbService _dbService;

    public PatientService(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    public async Task<PatientDTO> GetPatient(int id)
    {
        var patient = await _dbService.GetPatientWithPrescriptions(id);
        if (patient == null) throw new NotFound("No patient");
        var patientDto = new PatientDTO()
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.Birthdate
        };

        patientDto.Prescriptions = patient.Prescriptions.Select(p => new PatientPrescriptionDTO()
        {
            IdPrescription = p.IdPrescription,
            Date = p.Date,
            DueDate = p.DueDate,
            Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentDto()
            {
                IdMedicament = pm.IdMedicament,
                Name = pm.Medicament.Name,
                Dose = pm.Dose,
                Description = pm.Medicament.Description
            }).ToList(),
        }).OrderBy(pr => pr.DueDate).ToList();

        return patientDto;
    }
}