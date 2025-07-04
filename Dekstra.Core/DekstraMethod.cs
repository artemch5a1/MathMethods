using System.Diagnostics;

namespace Dekstra.Core
{
    public class DekstraMethod
    {
        public static int[] Solve(int[,] rutes, int startPoint)
        {
            int dlin = rutes.GetLength(0);
            int[] distance = new int[dlin];
            bool[] visited = new bool[dlin];

            for( int i = 0; i < dlin; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            distance[startPoint] = 0;
            visited[startPoint] = true;

            int currentPoint = startPoint;

            for( int i = 0; i < dlin - 1; i++)
            {
                int min = int.MaxValue;
                int index = -1;

                for ( int j = 0; j < dlin; j++)
                {
                    if (visited[j] == false && rutes[currentPoint, j] != 0)
                    {
                        int currentDistance = distance[currentPoint] + rutes[currentPoint, j];

                        if(currentDistance < distance[j])
                        {
                            distance[j] = currentDistance;
                        }

                        if(currentDistance < min)
                        {
                            min = currentDistance;
                            index = j;
                        }
                    }
                }

                if (index == -1)
                    break;

                visited[currentPoint] = true;
                currentPoint = index;
            }

            return distance;
        }
    }
}
