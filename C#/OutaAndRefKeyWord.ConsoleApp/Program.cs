namespace OutaAndRefKeyWord.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        decimal x = 100;
        AddRefKdv(ref x);

        decimal y;
        AddOutKdv(out y);


        Console.WriteLine("X değerimin sonucu: " + x);
    }

    private static void AddRefKdv(ref decimal x)
    {
        x *= 1.08m;
    }

    private static void AddOutKdv(out decimal y)
    {
        y = 100;
    }
}


