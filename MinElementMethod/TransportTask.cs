namespace MinElementMethod
{
    public class TransportTask
    {
        private static bool ContainsNull(int?[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == null)
                        return true; // Найден null
                }
            }
            return false; // null не найден
        }

        public static int?[,] SolveTask(int[] a, int[] b, int[,] tariff)
        {
            if (a.Length != tariff.GetLength(0) || b.Length != tariff.GetLength(1))
                throw new ArgumentException("Неверные данные");

            if (a.Sum() != b.Sum())
                throw new ArgumentException("Задача не является закрытой");

            int?[,] solution = new int?[a.Length, b.Length];

            while (ContainsNull(solution))
            {
                int min = int.MaxValue;
                int minI = -1; int minJ = -1;

                for(int i = 0;  i < a.Length; i++)
                {
                    for(int j = 0; j < b.Length; j++)
                    {
                        if (solution[i, j] == null && tariff[i, j] < min)
                        {
                            min = tariff[i, j];
                            minI = i;
                            minJ = j;
                        }
                    }
                }

                if (minI == -1)
                    break;

                int value = int.Min(a[minI], b[minJ]);

                solution[minI, minJ] = value;

                a[minI] -= value;
                b[minJ] -= value;
            }

            return solution;
        }
    }
}
