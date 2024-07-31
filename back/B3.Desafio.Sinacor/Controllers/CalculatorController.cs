using Microsoft.AspNetCore.Mvc;
using B3.Desafio.Sinacor.Services;
using B3.Desafio.Sinacor.Controllers.Response;

namespace B3.Desafio.Sinacor.Controllers;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{

    [HttpPost("cdi")]
    public ActionResult<CdiResponseDto> Get(decimal value, UInt32 months)
    {
        if (months >= 10_000) return BadRequest("The maximum number of months is 10.000");
        if (months <= 0) return BadRequest("The 'months' arguments must be greater than 0");
        if (value <= 0) return BadRequest("The 'value' arguments must be greater than 0");

        CdiResponseDto result =  new () {
            InitialValue = value,
            Incomes = Calculator.CalculateCDIByMonth(value, months) 
        };

        return result;
    }
}