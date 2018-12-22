using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Citi.Service.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Citi.Service.Data
{
    public class PositionService
    {
        private readonly PositionSettings _settings;
        private readonly IHubContext<UpdateHub> _hub;

        private readonly List<Symbol> _symbols;

        //Add positions repository
        private readonly Dictionary<Symbol, List<PositionItem>> _positions =
            new Dictionary<Symbol, List<PositionItem>>();

        //Add prices service
        private readonly Dictionary<Symbol, double> _prices = new Dictionary<Symbol, double>();
        private Timer _timer;

        public PositionService(PositionSettings settings, IHubContext<UpdateHub> hub)
        {
            _settings = settings;
            _hub = hub;
            _symbols = Enum.GetValues(typeof(Symbol)).Cast<Symbol>().ToList();

        }

        public void Start()
        {
            LoadData();
            _timer = new Timer(UpdatePositions, null, _settings.UpdateInterval, _settings.UpdateInterval);
        }

        private void LoadData()
        {
            foreach (var symbol in _symbols)
            {
                _positions[symbol] = new List<PositionItem>();
            }

            var symbolsCount = _symbols.Count;
            var generator = new Random();
            for (var i = 1; i < _settings.PositionsCount + 1; i++)
            {
                var position = new PositionItem
                {
                    PositionId = i,
                    Symbol = (Symbol) generator.Next(symbolsCount),
                    Quantity = generator.Next(1000)
                };
                _positions[position.Symbol].Add(position);
            }

            foreach (var symbol in _symbols)
            {
                _prices[symbol] = generator.NextDouble() * 1000;
                _positions[symbol].ForEach(position => position.UpdateSpot((decimal) _prices[symbol]));
            }
        }

        public List<PositionItem> GetPositions()
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

            var updatedPositions = new List<PositionItem>();
            foreach (var changedSymbol in changedSymbols)
            {
                _prices[changedSymbol] *= (generator.NextDouble() + 0.5);
                _positions[changedSymbol].ForEach(position => position.UpdateSpot((decimal) _prices[changedSymbol]));
                updatedPositions.AddRange(_positions[changedSymbol]);
            }

            _hub.Clients.All.SendAsync("position", updatedPositions.OrderBy(position => position.PositionId).ToArray());
        }
    }
}