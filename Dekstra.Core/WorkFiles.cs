using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekstra.Core
{
    public class WorkFiles
    {
        public static int[,] ReadFromCsv(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("нет файла");
            }

            if(Path.GetExtension(path).ToLower() != ".csv")
            {
                throw new FileNotFoundException("не тот файл");
            }

            string[] lines = File.ReadAllLines(path);

            if(lines.Length == 0 || lines == null)
            {
                throw new Exception("файл пуст");
            }

            int rows = lines.Length;
            int cols = lines[0].Split(';').Length;

            if(rows != cols)
            {
                throw new Exception("неверный формат данных");
            }

            int[,] graph = new int[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                if (lines[i].Split(';').Length != cols)
                {
                    throw new Exception("неверный формат данных");
                }

                string[] line = lines[i].Split(';').ToArray();

                for (int j = 0; j < cols; j++)
                {
                    if (!int.TryParse(line[j], out graph[i, j])) 
                    {
                        throw new Exception("не верный тип данных");
                    }
                }
            }

            return graph;
        }

        public static void WriteCsv(string path, int[] distance)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                for(int i = 0;i < distance.Length; i++)
                {
                    sw.WriteLine($"{i + 1};{distance[i]}");
                }
            }
        }
    }
}
