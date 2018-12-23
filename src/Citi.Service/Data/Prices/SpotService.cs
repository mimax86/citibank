using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Citi.Service.Data.Positions;

namespace Citi.Service.Data.Prices
{
    public class SpotService
    {
        private readonly DataGenerationSettings _settings;
        private readonly ReadOnlyCollection<Symbol> _symbols;
        private readonly Dictionary<Symbol, decimal> _prices;

        public SpotService(DataGenerationSettings settings)
        {
            _settings = settings;
            _symbols = Enum.GetValues(typeof(Symbol)).Cast<Symbol>().ToList().AsReadOnly();
            _prices = _symbols.ToDictionary(symbol => symbol, symbol => 0m);
            LoadPrices();
        }

        private void LoadPrices()
        {
            var generator = new Random();
            foreach (var symbol in _symbols)
            {
                _prices[symbol] = _settings.MinimumPrice + _settings.PriceRange * (decimal) generator.NextDouble();
            }
        }

        private List<Symbol> UpdatePrices()
        {
            var generator = new Random();
            var updatedSymbolsCount = generator.Next(_symbols.Count);
            var updatedSymbols = new List<Symbol>();
            for (int i = 0; i < updatedSymbolsCount; i++)
            {
                var updatedSymbol = (Symbol) generator.Next(_symbols.Count);
                updatedSymbols.Add(updatedSymbol);
                _prices[updatedSymbol] = _settings.MinimumPrice +
                                         _prices[updatedSymbol] *
                                         ((decimal) generator.NextDouble() + _settings.PriceFluctuation);
            }

            return updatedSymbols;
        }

        public ReadOnlyCollection<Symbol> GetSymbols()
        {
            return _symbols;
        }


        public ReadOnlyDictionary<Symbol, decimal> GetPrices()
        {
            return GetPrices(out _);
        }


        public ReadOnlyDictionary<Symbol, decimal> GetPrices(out List<Symbol> updatedSymbols)
        {
            updatedSymbols = UpdatePrices();
            return new ReadOnlyDictionary<Symbol, decimal>(_prices);
        }
    }
}