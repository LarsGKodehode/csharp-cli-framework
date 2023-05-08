internal class Application
{
  public static void Main()
  {
    var console = new CLI.CommandManager();

    var addons = new Addons.StringOperations();

    console.RegisterCommands(addons.Commands);

    console.AwaitInput();
  }
}
