using AvalphaTechnologies.CommissionCalculator.Models;
namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public interface ICommissionCalculatorService
    {
        CommissionCalculationResponse Calculate(CommissionCalculationRequest request);
    }
}
