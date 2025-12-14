using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AvalphaTechnologies.CommissionCalculator.Controllers;
using AvalphaTechnologies.CommissionCalculator.Services;
using AvalphaTechnologies.CommissionCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Tests.Controllers
{
    public class CommissionControllerTests
    {
        [Fact]
        public void Calculate_ReturnsExpectedResult()
        {
            var mockService = new Mock<ICommissionCalculatorService>();
            var inputRequest = new CommissionCalculationRequest
            {
                LocalSalesCount = 10,
                ForeignSalesCount = 10,
                AverageSaleAmount = 100m
            };
            mockService.Setup(s => s.Calculate(inputRequest))
                       .Returns(new CommissionCalculationResponse { AvalphaTechnologiesCommissionAmount = 550, CompetitorCommissionAmount = 95.5m });

            var controller = new CommisionController(mockService.Object);

            var request = new CommissionCalculationRequest { LocalSalesCount = 10, ForeignSalesCount = 10, AverageSaleAmount = 100 };
            var result = controller.Calculate(request) as OkObjectResult;
            var data = result.Value as CommissionCalculationResponse;

            Assert.Equal(550m, data.AvalphaTechnologiesCommissionAmount);
            Assert.Equal(95.5m, data.CompetitorCommissionAmount);
        }
    }
}
