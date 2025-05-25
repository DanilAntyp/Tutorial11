using Microsoft.AspNetCore.Mvc;
using Tutorial11.DTOs;
using Tutorial11.Exceptions;
using Tutorial11.Services;

namespace Tutorial11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController: ControllerBase
{

    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
        
        
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDTO prescriptionDto)
    {
        try
        {
            await _prescriptionService.AddPrescription(prescriptionDto);
        }
        catch (NotFound e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequest e)
        {
            return BadRequest(e.Message);
        }
        catch
        {
            return StatusCode(500, new { error = "Error" });
        }
        return Ok();
    }
}