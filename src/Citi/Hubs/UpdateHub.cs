using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Citi.Hubs
{
    public class UpdateHub : Hub
    {
        private readonly ILogger _logger;

        public UpdateHub(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<UpdateHub>();
        }

        public override Task OnConnectedAsync()
        {
            _logger.LogDebug("Registering a client");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogDebug("Unregistering a client");
            return base.OnDisconnectedAsync(exception);
        }
    }
}