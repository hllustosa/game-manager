using GameManagement.Services.Interfaces;
using System;

namespace GameManagement.Infra
{
    public class MockDateService : IDateService
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.MinValue;
        }
    }
}
