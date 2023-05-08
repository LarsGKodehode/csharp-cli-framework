namespace Logger
{
  public interface ILogger
  {
    void Response(string message);
    (string? value, bool? shutdown) TakeInput();
  }

  public class Terminal : ILogger
  {
    public void Response(string message)
    {
      System.Console.WriteLine(message);
    }

    public (string? value, bool? shutdown) TakeInput()
    {
      var response = System.Console.ReadLine();

      if (string.IsNullOrWhiteSpace(response))
      {
        System.Console.WriteLine("Empty command not allowed");
        return (null, null);
      }

      if (response.Equals("q") || response.Equals("quit"))
      {
        System.Console.WriteLine("Shutdown command recieved");
        return (null, true);
      }

      return (response.TrimEnd().TrimStart(), null);
    }
  }
}
