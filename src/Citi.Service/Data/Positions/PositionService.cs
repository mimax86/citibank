using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Citi.Service.Data.Positions;
using Citi.Service.Data.Prices;
using Citi.Service.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Citi.Service.Data
{
    public class PositionService
    {
        private readonly SpotService _spotService;
        private readonly DataGenerationSettings _settings;
        private readonly IHubContext<UpdateHub> _updateHub;
        private Dictionary<Symbol, List<PositionItem>> _positions;
        private Timer _timer;

        public PositionService(SpotService spotService, DataGenerationSettings settings, IHubContext<UpdateHub> updateHub)
        {
            _spotService = spotService;
            _settings = settings;
            _updateHub = updateHub;
        }

        public void Start()
        {
            LoadPositions();
            _timer = new Timer(UpdatePositions, null, _settings.UpdateInterval, _settings.UpdateInterval);
        }

        public List<PositionItem> GetPositions()
        {
            return _positions.Values.SelectMany(items => items)
                .OrderBy(position => position.PositionId).ToList();
        }

        private void LoadPositions()
        {
            _positions = _spotService.GetSymbols()
                .ToDictionary(symbol => symbol, symbol => new List<PositionItem>());
            var generator = new Random();
            var symbolsCount = _spotService.GetSymbols().Count;
            var prices = _spotService.GetPrices();
            for (var i = 0; i < _settings.PositionsCount; i++)
            {
                var position = new PositionItem
                {
                    PositionId = i + 1,
                    Symbol = (Symbol) generator.Next(symbolsCount),
                    Quantity = generator.Next(_settings.MinimumQuantity, _settings.MaximumQuantity)
                };
                position.UpdateSpot(prices[position.Symbol]);
                _positions[position.Symbol].Add(position);
            }
        }

        private void UpdatePositions(object state)
        {
            var updatedPositions = new List<PositionItem>();
            var prices = _spotService.GetPrices(out List<Symbol> updatedSymbols);

            foreach (var updatedSymbol in updatedSymbols)
            {
                _positions[updatedSymbol].ForEach(position => position.UpdateSpot(prices[updatedSymbol]));
                updatedPositions.AddRange(_positions[updatedSymbol]);
            }

            _updateHub.Clients.All.SendAsync("position", updatedPositions.ToArray());
        }
    }
}