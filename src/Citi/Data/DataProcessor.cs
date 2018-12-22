using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using Citi.Hubs;

namespace Citi.Data
{
    public class DataProcessor
    {
        private readonly DataSettings _settings;
        private readonly IHubContext<UpdateHub> _hub;

        private readonly List<Symbol> _symbols;

        //Add positions repository
        private readonly Dictionary<Symbol, List<PositionLevelRisk>> _positions =
            new Dictionary<Symbol, List<PositionLevelRisk>>();

        //Add prices service
        private readonly Dictionary<Symbol, double> _prices = new Dictionary<Symbol, double>();
        private readonly Timer _timer;

        public DataProcessor(DataSettings settings, IHubContext<UpdateHub> hub)
        {
            _settings = settings;
            _hub = hub;
            _symbols = Enum.GetValues(typeof(Symbol)).Cast<Symbol>().ToList();
            LoadData();
            _timer = new Timer(UpdatePositions, null, settings.UpdateInterval, settings.UpdateInterval);
        }

        private void LoadData()
        {
            foreach (var symbol in _symbols)
            {
                _positions[symbol] = new List<PositionLevelRisk>();
            }

            var symbolsCount = _symbols.Count;
            var generator = new Random();
            for (var i = 0; i < _settings.PositionsCount; i++)
            {
                var position = new PositionLevelRisk
                {
                    PositionId = i,
                    Symbol = (Symbol) generator.Next(symbolsCount),
                    Quantity = generator.NextDouble() * 100
                };
                _positions[position.Symbol].Add(position);
            }

            foreach (var symbol in _symbols)
            {
                _prices[symbol] = generator.NextDouble() * 1000;
                _positions[symbol].ForEach(position => position.UpdateSpot(_prices[symbol]));
            }
        }

        public List<PositionLevelRisk> GetPositions()
        {
            return _positions.Values.SelectMany(potionsForSynbol => potionsForSynbol)
                .OrderBy(position => position.PositionId).ToList();
        }

        private void UpdatePositions(object state)
        {
            var generator = new Random();
            var numberOfRandonlyPickedSymbols = generator.Next(_symbols.Count);
            var changedSymbols = new HashSet<Symbol>();
            for (int i = 0; i < numberOfRandonlyPickedSymbols; i++)
            {
                changedSymbols.Add((Symbol) generator.Next(_symbols.Count));
            }

            if (!changedSymbols.Any())
                return;

            var updatedPositions = new List<PositionLevelRisk>();
            foreach (var changedSymbol in changedSymbols)
            {
                _prices[changedSymbol] *= (generator.NextDouble() + 0.5);
                _positions[changedSymbol].ForEach(position => position.UpdateSpot(_prices[changedSymbol]));
                updatedPositions.AddRange(_positions[changedSymbol]);
            }

            _hub.Clients.All.SendAsync("ALL", updatedPositions.OrderBy(position => position.PositionId).ToArray());
        }
    }
}