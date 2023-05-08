internal class Application
{
  public static void Main()
  {
    var console = new CLI.CommandManager();

    var stringCommands = new Addons.StringOperations();
    console.RegisterCommands(stringCommands.Commands);

    var graphCommands = new Addons.GraphOperations();
    console.RegisterCommands(graphCommands.Commands);

    console.AwaitInput();
  }
}
