namespace Common.Uitlities;
public class PrintInConsole
{
    public static void PrintWithColor(Action colorSet, params string[] messages)
    {
        colorSet.Invoke();

        foreach (var msg in messages) 
            Console.WriteLine(msg);

        Console.ForegroundColor = ConsoleColor.White;
    }
}
