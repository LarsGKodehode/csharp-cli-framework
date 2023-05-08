using System;
using System.Collections.Generic;

namespace CLI
{
  public interface ICommand
  {
    void Execute();
  }

  public class CommandManager
  {
    private readonly Dictionary<string, Action> commands;

    public CommandManager()
    {
      commands = new Dictionary<string, Action>();
    }

    public void RegisterCommands(Dictionary<string, Action> newCommands)
    {
      foreach (var command in newCommands)
      {
        commands[command.Key] = command.Value;
      }
    }

    private void TryToExecuteCommand(string commandName)
    {
      if (commands.TryGetValue(commandName, out var command))
      {
        command();
      }
      else
      {
        Console.WriteLine("Command not found.");
      }
    }

    public void WaitForCommand()
    {
      while (true)
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

        TryToExecuteCommand(result.TrimEnd().TrimStart());
      }
    }
  }
}
