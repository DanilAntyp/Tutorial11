using Tutorial11.DTOs;

namespace Tutorial11.Services;

public interface IPatientService
{
    Task<PatientDTO> GetPatient(int id);
}