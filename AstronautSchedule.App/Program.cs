using System;
using AstronautSchedule.Core.Models;
using AstronautSchedule.Core.Factories;
using AstronautSchedule.Core.Managers;


namespace AstronautSchedule.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedule = ScheduleManager.get_instance();
            var factory = new AstronautTaskFactory();




            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Astronaut Daily Schedule ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. View Tasks");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        add_task_menu(factory, schedule);
                        break;
                    case "2":
                        remove_task_menu(schedule);
                        break;
                    case "3":
                        schedule.view_tasks();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void add_task_menu(AstronautTaskFactory factory, ScheduleManager schedule)
        {
            Console.Write("Enter task description: ");
            string? desc = Console.ReadLine();

            Console.Write("Enter start time (HH:mm): ");
            string? start = Console.ReadLine();

            Console.Write("Enter end time (HH:mm): ");
            string? end = Console.ReadLine();

            Console.Write("Enter priority (Low, Medium, High): ");
            string? pri = Console.ReadLine();

            var task = factory.create_task(desc!, start!, end!, pri!);
            schedule.add_task(task);
        }


        static void remove_task_menu(ScheduleManager schedule)
        {
            Console.Write("Enter task description to remove: ");
            string? desc = Console.ReadLine();
            schedule.remove_task(desc!);
        }
    }
}
