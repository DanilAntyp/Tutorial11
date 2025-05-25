using Microsoft.AspNetCore.Mvc;
using Tutorial11.Exceptions;
using Tutorial11.Services;

namespace Tutorial11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
        
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        try
        {
            var patientDTO = await _patientService.GetPatient(id);
            return Ok(patientDTO);
        }
        catch (NotFound e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            throw;
        }

    }
}