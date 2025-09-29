using System;

namespace AstronautSchedule.Core.Models
{
    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }

    public class TaskItem
    {
        public string Description { get; set; }
        public string StartTime { get; set; }   
        public string EndTime { get; set; }   
        public PriorityLevel Priority { get; set; }
        public bool IsCompleted { get; set; } = false;

        public TaskItem(string description, string startTime, string endTime, PriorityLevel priority)
        {
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Priority = priority;
        }
    }
}
