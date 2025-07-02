using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruferCode.Core.Methods
{
    public class CodePrufer
    {
        public Tree tree { get; protected set; }

        public CodePrufer(string validString)
        {
            tree = new Tree(validString);
        }

        public string CodePruferByTree()
        {
            string pruferCode = string.Empty;

            for (int i = 0; i < tree.Highs.Count - 2; i++)
            {

            } 

            return pruferCode;
        }
    }
}
