using System;
using System.Collections.Generic;

namespace CLI
{
  // The fields and methods required for a command
  public interface ICommand
  {
    // The name to use for running this command
    string Name { get; }
    // The function for running this command
    void Execute();
  }

  // The console application
  public class CommandManager
  {
    private bool close = false;
    private Dictionary<string, ICommand> commands;

    public CommandManager() {
      commands = new Dictionary<string, ICommand>();
    }

    private static void Execute(string command)
    {
      // Takes a command and tries to execute the corresponding command from the command list
      Console.WriteLine($"Executing command: {command}");
    }

    // This will start querrying for commands in the terminal
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
          close = true;
          continue;
        }

        Execute(result.TrimEnd().TrimStart());
      }
    }
  }
}
