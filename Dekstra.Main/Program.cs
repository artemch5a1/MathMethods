using Dekstra.Core;

int[,] graph = {
    { 0,  7,  9,  0,  0, 14 },
    { 7,  0, 10, 15,  0,  0 },
    { 9, 10,  0, 11,  0,  2 },
    { 0, 15, 11,  0,  6,  0 },
    { 0,  0,  0,  6,  0,  9 },
    {14,  0,  2,  0,  9,  0 }
};

int[,] graphFrom = WorkFiles.ReadFromCsv("dek.csv");

int[] res = DekstraMethod.Solve(graphFrom, 0);

WorkFiles.WriteCsv("res.csv", res);

Console.ReadLine();
