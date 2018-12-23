using System;
using System.Threading;
using Citi.Service.Data;
using Citi.Service.Data.Positions;
using Citi.Service.Data.Prices;
using Citi.Service.Hubs;
using Citi.Service.Timing;
using FluentAssertions;
using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;

namespace Citi.Tests
{
    public class PositionServiceTests
    {
        private PositionService _service;
        private Mock<IClientProxy> _clientProxyMock;
        private DataGenerationSettings _settings;
        private Action _handler;

        [SetUp]
        public void Setup()
        {
            var timerFactoryMock = new Mock<ITimerFactory>();
            timerFactoryMock.Setup(factory => factory.Create(It.IsAny<Action>()))
                .Returns(new Mock<ITimer>().Object)
                .Callback<Action>(handler => _handler = handler);
            _settings = new DataGenerationSettings();

            _clientProxyMock = new Mock<IClientProxy>();
            var hubClients = new Mock<IHubClients>();
            hubClients.Setup(clients => clients.All).Returns(_clientProxyMock.Object);
            var hubMock = new Mock<IHubContext<UpdateHub>>();
            hubMock.Setup(hub => hub.Clients)
                .Returns(hubClients.Object);
            _service = new PositionService(new SpotService(_settings), timerFactoryMock.Object, _settings,
                hubMock.Object);
        }

        [Test]
        public void PositionService_Throws_Exception_If_Not_Started()
        {
            Action action = () => _service.GetPositions();
            action.Should().Throw<Exception>();
        }

        [Test]
        public void PositionService_Returns_Positions_After_Start()
        {
            _service.Start();
            _service.GetPositions().Count.Should().Be(_settings.PositionsCount);
        }

        [Test]
        public void PositionService_Invokes_Hub_To_Push_Positions_Notification()
        {
            _service.Start();
            _handler.Invoke();
            _clientProxyMock.Verify(proxy => proxy.SendCoreAsync(It.Is<string>(value => value == "position"),
                It.Is<object[]>(args => args[0] is PositionItem[]), It.IsAny<CancellationToken>()));
        }
    }
}