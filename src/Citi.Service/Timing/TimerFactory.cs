using System;
using Citi.Service.Data;
using Microsoft.Extensions.Logging;

namespace Citi.Service.Timing
{
    public class TimerFactory : ITimerFactory
    {
        private readonly DataGenerationSettings _settings;
        private readonly ILoggerFactory _loggerFactory;

        public TimerFactory(DataGenerationSettings settings,
            ILoggerFactory loggerFactory)
        {
            _settings = settings;
            _loggerFactory = loggerFactory;
        }

        public ITimer Create(Action handler)
        {
            return new Timer(_settings, _loggerFactory, handler);
        }
    }
}