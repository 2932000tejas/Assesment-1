using Microsoft.AspNetCore.Mvc;
using AvalphaTechnologies.CommissionCalculator.Models;
using AvalphaTechnologies.CommissionCalculator.Services;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        private readonly ICommissionCalculatorService _commissionService;

        public CommisionController(ICommissionCalculatorService commissionService)
        {
            _commissionService = commissionService;
        }

        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult Calculate([FromBody] CommissionCalculationRequest request)
        {
            try
            {
                var result = _commissionService.Calculate(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
