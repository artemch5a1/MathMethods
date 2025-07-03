
using PruferCode;
using PruferCode.Core.Methods;

Console.WriteLine("Введи епта");



if (true)
{
    try
    {
        string rebers = CsvWorker.ImportStringFromCsv("Input.csv");

        Tree tree = new Tree(rebers);

        string code = CodeMethods.CodePruferByTree(tree);

        Console.WriteLine(code);

        CsvWorker.ExportCsv(code, "Output.csv");
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}
