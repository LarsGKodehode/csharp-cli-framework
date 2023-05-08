using System;
using System.Collections.Generic;

namespace Addons
{
  public interface IAddon
  {
    Dictionary<string, Action> Commands { get; }
  }

  public class StringOperations : IAddon
  {
    public Dictionary<string, Action> Commands => new Dictionary<string, Action>
    {
      {
        "CommandA",
        () => System.Console.WriteLine("Executing a command A")
      },
      {
        "CommandB",
        () => System.Console.WriteLine("Executing a command B")
      },
      {
        "CommandC",
        () => System.Console.WriteLine("Executing a command C")
      },
    };
  }

  public class GraphOperations : IAddon
  {
    public Dictionary<string, Action> Commands => new Dictionary<string, Action>
    {
      {
        "CommandA",
        () => System.Console.WriteLine("Executing a command A")
      },
      {
        "CommandB",
        () => System.Console.WriteLine("Executing a command B")
      },
      {
        "CommandC",
        () => System.Console.WriteLine("Executing a command C")
      },
    };
  }
}
