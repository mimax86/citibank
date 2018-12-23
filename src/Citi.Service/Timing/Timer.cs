using System;
using Citi.Service.Data;
using Microsoft.Extensions.Logging;
using InternalTimer = System.Threading.Timer;

namespace Citi.Service.Timing
{
    public class Timer : ITimer
    {
        private readonly DataGenerationSettings _settings;
        private readonly Action _handler;
        private readonly ILogger _logger;
        private InternalTimer _timer;

        public Timer(DataGenerationSettings settings, ILoggerFactory loggerFactory,
            Action handler)
        {
            _settings = settings;
            _handler = handler;
            _logger = loggerFactory.CreateLogger<Timer>();
        }

        public void Start()
        {
            _timer = new InternalTimer(state =>
                {
                    try
                    {
                        _handler();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Failed to proceess time job", e);
                    }
                }, null, _settings.UpdateInterval,
                _settings.UpdateInterval);
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}