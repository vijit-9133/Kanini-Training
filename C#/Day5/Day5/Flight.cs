using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Flight
    {
        private static Dictionary<string, DateTime> flightSchedule = new Dictionary<string, DateTime>
    {
        { "Ar456", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 0) },
        { "De789", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 00, 0) },
        { "Lh101", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 9, 30, 0) } 
    };
        public string flightStatus(string flightNumber)
        {
            if (flightSchedule.ContainsKey(flightNumber))
            {
                DateTime departureTime = flightSchedule[flightNumber];
                DateTime currentTime = DateTime.Now;

                TimeSpan td = departureTime - currentTime;

                if (td.TotalSeconds > 0)
                {
                    return $"Time To Flight {td:hh\\:mm\\:ss\\.fffffff}";
                }
                else
                {
                    return "Flight Already Left";
                }
            }
            else
            {
                return "Flight number not found.";
            }

        }
    }
}
