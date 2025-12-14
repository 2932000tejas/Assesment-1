using AvalphaTechnologies.CommissionCalculator.Models;
namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public class CommissionCalculatorService : ICommissionCalculatorService
    {
        private const decimal AvalphaLocalRate = 0.20m;
        private const decimal AvalphaForeignRate = 0.35m;
        private const decimal CompetitorLocalRate = 0.02m;
        private const decimal CompetitorForeignRate = 0.0755m;

        public CommissionCalculationResponse Calculate(CommissionCalculationRequest request)
        {
            Validate(request);

            decimal localBase = request.LocalSalesCount * request.AverageSaleAmount;
            decimal foreignBase = request.ForeignSalesCount * request.AverageSaleAmount;

            var avalphaTotal =
                (localBase * AvalphaLocalRate) +
                (foreignBase * AvalphaForeignRate);

            var competitorTotal =
                (localBase * CompetitorLocalRate) +
                (foreignBase * CompetitorForeignRate);

            return new CommissionCalculationResponse
            {
                AvalphaTechnologiesCommissionAmount = avalphaTotal,
                CompetitorCommissionAmount = competitorTotal
            };
        }

        private static void Validate(CommissionCalculationRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request body is required");

            if (request.LocalSalesCount < 0 || request.ForeignSalesCount < 0)
                throw new ArgumentException("Sales counts must be greater than or equal to zero");

            if (request.AverageSaleAmount <= 0 || request.AverageSaleAmount > 1_000_000)
                throw new ArgumentException("Average sale amount must be between 1 and 1,000,000");
        }
    }
}
