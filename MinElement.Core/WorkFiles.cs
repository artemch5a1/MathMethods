using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinElementMethod
{
    public static class WorkFiles
    {
        private static int[,] ReadArrayFromCsv(string[] lines)
        {
            int rows = lines.Length;
            int cols = lines[0].Split(";").Length;

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] line = lines[i].Split(";");

                if (line.Length != cols)
                    throw new Exception("Неверный формат файла");

                for (int j = 0; j < cols; j++)
                {
                    if (!int.TryParse(line[j], out result[i, j]))
                    {
                        throw new Exception("Неверный формат файла");
                    }
                }
            }

            return result;
        }

        public static ( int[] sup, int[] cust, int[,] tariff ) ReadFromCsv(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new Exception("файл не сущ");
                }
                if (Path.GetExtension(path).ToLower() != ".csv")
                {
                    throw new Exception("неверный формат файла");
                }

                string[] lines = File.ReadAllLines(path);

                if (lines.Length == 0)
                {
                    throw new Exception("файл пуст");
                }

                int[] sup = lines[0].Split(';').Select(int.Parse).ToArray();
                int[] cust = lines[1].Split(';').Select(int.Parse).ToArray();

                string[] lineArray = lines.Skip(2).ToArray();

                int[,] tariff = ReadArrayFromCsv(lineArray);

                return (sup, cust, tariff);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            finally
            {

            }
        }

        public static void WriteCsv(string path, int[,] solution)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                for(int i = 0; i < solution.GetLength(0); i++)
                {
                    string[] stroke = new string[solution.GetLength(1)];
                    for(int j = 0;  j < solution.GetLength(1); j++)
                    {
                        stroke[j] = solution[i, j].ToString();
                    }
                    sw.WriteLine(string.Join(';', stroke));
                }
            }
        }
    }
}
