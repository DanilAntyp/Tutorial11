using Tutorial11.DTOs;

namespace Tutorial11.Services;

public interface IPrescriptionService
{
    Task<int> AddPrescription(PrescriptionDTO prescriptionDto);
}