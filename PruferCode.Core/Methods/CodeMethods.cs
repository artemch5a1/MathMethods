using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruferCode.Core.Methods
{
    public static class CodeMethods
    {
        private static bool isList(int high, List<int[]> rebers)
        {
            bool flag = false;
            foreach (int[] item in rebers)
            {
                if (item[1] == high)
                    flag = true;

                if (item[0] == high)
                    return false;
            }
            return flag;
        }

        private static List<int[]> NewListRebers(List<int[]> rebers)
        {
            List<int[]> newRebers = new List<int[]>();

            foreach (int[] item in rebers)
            {
                newRebers.Add([item[0], item[1]]);
            }

            return newRebers;
        }

        public static string CodePruferByTree(Tree tree)
        {
            string pruferCode = string.Empty;

            List<int[]> rebers = NewListRebers(tree.Rebers);

            for (int i = 0; i < tree.Highs.Count - 2; i++)
            {
                List<int> listList = new List<int>();
                foreach(int item in tree.Highs)
                {
                    if(isList(item, rebers))
                        listList.Add(item);
                }

                int minList = listList.Min();

                int[] rebro = rebers.FirstOrDefault(x => x[1] == minList);

                pruferCode = pruferCode + $"{rebro[0]}";

                rebers.Remove(rebro);
            } 

            return pruferCode;
        }
    }
}
