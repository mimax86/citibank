using System;

namespace Citi.Service.Timing
{
    public interface ITimerFactory
    {
        ITimer Create(Action handler);
    }
}