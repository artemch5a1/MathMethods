
using PruferCode;

Console.WriteLine("Введи епта");

string? mes = Console.ReadLine();

if (mes != null)
{
    try
    {
        Tree tree = new Tree(mes);
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}
