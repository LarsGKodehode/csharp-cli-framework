using System;

namespace CLI
{
    // The fields and methods required for a command
    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }

    // The console application
    public class App
    {
        private readonly bool close = false;

        private static void Execute(string command)
        {
            // Takes a command and tries to execute the corresponding command from the command list
            Console.WriteLine($"Executing command: {command}");
        }

        public void Run()
        {
            while (!close)
            {
                Console.WriteLine("Please enter a command ('q' or 'quit' for exit):");
                var result = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Empty command not allowed");
                    continue;
                }

                if (result.Equals("q") || result.Equals("quit"))
                {
                    break;
                }

                Execute(result.TrimEnd().TrimStart());
            }
        }
    }
}
