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
    private readonly Logger.ILogger IOHandler;

    public CommandManager(Logger.ILogger logger)
    {
      commands = new Dictionary<string, Action>();
      IOHandler = logger;
    }

    public void RegisterCommands(Dictionary<string, Action> newCommands)
    {
      foreach (var command in newCommands)
      {
        if (commands.ContainsKey(command.Key))
        {

          throw new InvalidOperationException("Multiple commands with the same name detected! Check your addons!");
        }
        else
        {
          commands[command.Key] = command.Value;
        }
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
        IOHandler.Response("Command not found.");
      }
    }

    public void AwaitInput()
    {
      while (true)
      {
        IOHandler.Response("Please enter a command ('q' or 'quit' for exit):");
        var result = IOHandler.TakeInput();

        if (result.shutdown.HasValue)
        {
          break;
        }

        if (string.IsNullOrEmpty(result.value))
        {
          continue;
        }

        TryToExecuteCommand(result.value);
      }
    }
  }
}
