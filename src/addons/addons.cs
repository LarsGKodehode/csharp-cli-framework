using System;
using System.Collections.Generic;

namespace Addons
{
  public class StringOperations
  {
    public Dictionary<string, Action> Commands;

    public StringOperations()
    {
      Commands = new Dictionary<string, Action>
        {
          {
            "CommandA",
            () => System.Console.WriteLine("Executing a command A")
          },
          {
            "CommandB",
            () => System.Console.WriteLine("Executing a command B")
          },
        };
    }
  }
}
