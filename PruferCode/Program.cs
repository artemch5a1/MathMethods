
using PruferCode;
using PruferCode.Core.Methods;

Console.WriteLine("Введи епта");



if (true)
{
    try
    {
        Tree tree = new Tree("1 2, 1 3, 1 4, 2 5, 2 6, 5 7, 6 8, 6 9, 3 10");

        Console.WriteLine(CodeMethods.CodePruferByTree(tree));
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}
