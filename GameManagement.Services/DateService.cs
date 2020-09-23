using GameManagement.Services.Interfaces;
using System;

namespace GameManagement.Services
{
    public class DateService : IDateService
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
