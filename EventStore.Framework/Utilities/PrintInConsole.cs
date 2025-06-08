using EventStore.Framework.Utilities;

namespace EventStoreFramework.Utilities;
public class PrintInConsole
{
    private static readonly Dictionary<Colors, Action> _consoleColors = new()
    {
        [Colors.Green] = () => { Console.ForegroundColor = ConsoleColor.Green; },
        [Colors.Blue] = () => { Console.ForegroundColor = ConsoleColor.Blue; },
        [Colors.White] = () => { Console.ForegroundColor = ConsoleColor.White; },
        [Colors.Red] = () => { Console.ForegroundColor = ConsoleColor.Red; },
    };
    public static void PrintWithColor(Colors color, params string[] messages)
    {
        _consoleColors[color]();

        foreach (var msg in messages) 
            Console.WriteLine(msg);


        _consoleColors[Colors.White]();
    }
}
