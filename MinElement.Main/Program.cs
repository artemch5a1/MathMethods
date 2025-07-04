using MinElementMethod;

if (true)
{
    try
    {
        //        int[,] tariff = {
        //    { 16, 26, 12, 24,  3 },
        //    {  5,  2, 19, 27,  2 },
        //    { 29, 23, 25, 16,  8 },
        //    {  2, 25, 14, 15, 21 }
        //};

        //        var result = TransportTask.SolveTask(new int[] { 14, 14, 14, 14 }, new int[] { 13, 5, 13, 12, 13 }, tariff);

        (int[] a, int[] b, int[,] tariff) resultRead = WorkFiles.ReadFromCsv("min.csv");

        int[,] result = TransportTask.SolveTask(resultRead.a, resultRead.b, resultRead.tariff);

        int func = TransportTask.CelFunc(resultRead.tariff, result);

        WorkFiles.WriteCsv("rezult.csv", result);

        (int[] a, int[] b, int[,] tariff) resultRead2 = WorkFiles.ReadFromCsv("min.csv");

        int[,] result2 = TransportTask.SolveSever(resultRead2.a, resultRead2.b, resultRead2.tariff);

        WorkFiles.WriteCsv("rezult2.csv", result2);
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}
