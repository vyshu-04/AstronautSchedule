using System;
using AstronautSchedule.Core.Models;

namespace AstronautSchedule.Core.Factories
{
    public class AstronautTaskFactory
    {
        public TaskItem? create_task(string description, string starttime, string endtime, string priority)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Error: Description cannot be empty.");
                return null;
            }

            if (!is_valid_time(starttime) || !is_valid_time(endtime))
            {
                Console.WriteLine("Error: Time must be in HH:mm format.");
                return null;
            }

            PriorityLevel pri;
            switch (priority.ToLower())
            {
                case "high": pri = PriorityLevel.High; break;
                case "medium": pri = PriorityLevel.Medium; break;
                case "low": pri = PriorityLevel.Low; break;
                default:
                    Console.WriteLine("Error: Priority must be Low, Medium, or High.");
                    return null;
            }

            return new TaskItem(description, starttime, endtime, pri);
        }

        private bool is_valid_time(string time)
        {
            return TimeSpan.TryParseExact(time, "hh\\:mm", null, out _);
        }
    }
}
