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

        var result = TransportTask.SolveTask(resultRead.a, resultRead.b, resultRead.tariff);

    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}
