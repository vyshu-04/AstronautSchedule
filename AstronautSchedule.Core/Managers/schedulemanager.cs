using System;
using System.Collections.Generic;
using AstronautSchedule.Core.Models;

namespace AstronautSchedule.Core.Managers
{
    public class ScheduleManager
    {
        private static ScheduleManager? instance = null;
        private List<TaskItem> tasks;

        private ScheduleManager()
        {
            tasks = new List<TaskItem>();
        }

    
        public static ScheduleManager get_instance()
        {
            if (instance == null)
                instance = new ScheduleManager();
            return instance;
        }


        public bool add_task(TaskItem? newtask)
        {
            if (newtask == null) return false;

            foreach (var t in tasks)
            {
                if (is_overlap(t, newtask))
                {
                    Console.WriteLine($"Error: Task conflicts with existing task '{t.Description}'.");
                    return false;
                }
            }

            tasks.Add(newtask);
            Console.WriteLine("Task added successfully.");
            return true;
        }

        public bool remove_task(string description)
        {
            var task = tasks.Find(t => t.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (task == null)
            {
                Console.WriteLine("Error: Task not found.");
                return false;
            }

            tasks.Remove(task);
            Console.WriteLine("Task removed successfully.");
            return true;
        }

        // view tasks sorted by start time
        public void view_tasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks scheduled for the day.");
                return;
            }

            tasks.Sort((a, b) => TimeSpan.Parse(a.StartTime).CompareTo(TimeSpan.Parse(b.StartTime)));

            foreach (var t in tasks)
            {
                string status = t.IsCompleted ? "[Completed]" : "";
                Console.WriteLine($"{t.StartTime} - {t.EndTime}: {t.Description} [{t.Priority}] {status}");
            }
        }


        private bool is_overlap(TaskItem existing, TaskItem newtask)
        {
            if (!TimeSpan.TryParse(existing.StartTime, out var start1)) return false;
            if (!TimeSpan.TryParse(existing.EndTime, out var end1)) return false;
            if (!TimeSpan.TryParse(newtask.StartTime, out var start2)) return false;
            if (!TimeSpan.TryParse(newtask.EndTime, out var end2)) return false;

            return start1 < end2 && start2 < end1;
        }
    }
}
