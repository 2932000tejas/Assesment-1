using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AvalphaTechnologies.CommissionCalculator.Services;
using AvalphaTechnologies.CommissionCalculator.Models;

namespace AvalphaTechnologies.CommissionCalculator.Tests.Services
{
    public class CommissionCalculatorServiceTests
    {
        private readonly CommissionCalculatorService _service;

        public CommissionCalculatorServiceTests()
        {
            _service = new CommissionCalculatorService();
        }

        [Fact]
        public void Calculate_ShouldReturnCorrectCommission()
        {
            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = 10,
                ForeignSalesCount = 10,
                AverageSaleAmount = 100m
            };

            var result = _service.Calculate(request);

            Assert.Equal(550m, result.AvalphaTechnologiesCommissionAmount);
            Assert.Equal(95.5m, result.CompetitorCommissionAmount);
        }

        [Fact]
        public void Calculate_ShouldReturnZero_WhenAllInputsAreZero()
        {            
            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = 0,
                ForeignSalesCount = 0,
                AverageSaleAmount = 0
            };
            var result = _service.Calculate(request);
            Assert.Equal(0m, result.AvalphaTechnologiesCommissionAmount);
            Assert.Equal(0m, result.CompetitorCommissionAmount);
        }
    }
}
