namespace PruferCode
{
    public class Tree
    {
        public List<int[]> Rebers { get; private set; }

        public List<int> Highs { get; private set; }

        public Tree(string rebersTrees)
        {
            Rebers = Processing(rebersTrees);
            Highs = ProcessingHighs(Rebers);
        }

        private static List<int[]> Processing(string rebersString)
        {
            List<int[]> highs = new List<int[]>();

            for (int i = 0; i < rebersString.Split(" ").Length; i++)
            {
                int[] high = new int[2];
                int count = 0;

                if (rebersString.Split(" ")[i].Split(';').Length != 2)
                    throw new ArgumentException("Неверный формат строки");

                foreach (string t in rebersString.Split(" ")[i].Split(';'))
                {
                    if(!int.TryParse(t, out high[count]))
                    {
                        throw new ArgumentException("Неверный формат строки");
                    }
                    count++;
                }
                highs.Add(high);    
            }

            return highs;
        }

        private static List<int> ProcessingHighs(List<int[]> rebersTrees)
        {
            List<int> ints = new List<int>();

            foreach (int[] item in rebersTrees)
            {
                foreach(int high in item) 
                {
                    if (!ints.Contains(high))
                    {
                        ints.Add(high);
                    }
                }
            }
            return ints;
        }
    }
}
