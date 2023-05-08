internal class Application
{
  public static void Main()
  {
    var Logger = new Logger.Terminal();

    var console = new CLI.CommandManager(Logger);

    var stringCommands = new Addons.StringOperations();
    console.RegisterCommands(stringCommands.Commands);

    var graphCommands = new Addons.GraphOperations();
    console.RegisterCommands(graphCommands.Commands);

    console.AwaitInput();
  }
}
