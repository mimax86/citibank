using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Citi.Service.Data;
using Citi.Service.Data.Positions;
using Citi.Service.Data.Prices;

namespace Citi.Tests
{
    [TestFixture]
    public class SpotServiceTests
    {
        private DataGenerationSettings _settings;
        private SpotService _service;

        [SetUp]
        public void SetUp()
        {
            _settings = new DataGenerationSettings();
            _service = new SpotService(_settings);
        }

        [Test]
        public void SpotService_Returns_All_Symbols()
        {
            var count = Enum.GetValues(typeof(Symbol)).Length;
            _service.GetSymbols().Count.Should().Be(count);
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void SpotService_Returns_Positive_Prices_Iteratively(int updatesCount)
        {
            var count = Enum.GetValues(typeof(Symbol)).Length;
            Enumerable.Range(0, updatesCount).ToList().ForEach(attemp =>
            {
                var prices = _service.GetPrices().ToList();
                prices.Count.Should().Be(count);
                prices.ForEach(price => price.Value.Should().BePositive());
            });
        }
    }
}