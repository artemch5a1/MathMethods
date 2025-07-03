using PruferCode.Core.Methods;

namespace PruferCode.Tests
{
    public class TreeTests
    {
        private bool IsEgualListRebers(List<int[]> actual, List<int[]> expected)
        {
            if(actual.Count != expected.Count)
                return false;

            for(int i = 0; i < actual.Count; i++)
            {
                if(actual[i].Length != expected[i].Length) 
                    return false;

                for(int j = 0; j < actual[i].Length; j++)
                {
                    if(actual[i][j] != expected[i][j])
                        return false;
                }
            }
            return true;
        }

        private bool IsEgualListHighs(List<int> actual, List<int> expected)
        {
            if (actual.Count != expected.Count)
                return false;

            for (int j = 0; j < actual.Count; j++)
            {
                if (actual[j] != expected[j])
                    return false;
            }
            return true;
        }

        [Fact]
        public void CtorTree_ValidString_ShouldReturnValidTree()
        {
            //Arrange
            List<int[]> expected = new List<int[]>() { new int[] { 1, 2 }, new int[] { 4, 5 }, new int[] { 5, 6 } };

            string validString = "1;2 4;5 5;6";

            //Act
            Tree actual = new Tree(validString);

            //Assert
            Assert.True(IsEgualListRebers(actual.Rebers, expected));

        }

        [Fact]
        public void CtorTree_InvalidString_ShouldThrowEx()
        {
            //Arrange
            List<int[]> expected = new List<int[]>() { new int[] { 1, 2 }, new int[] { 4, 5 }, new int[] { 5, 6 } };

            string invalidString = "12 455 56";

            //Act && Assert
            var ex = Assert.Throws<ArgumentException>(() => new Tree(invalidString));
        }

        [Fact]
        public void Ctor_ValidString_ShouldReturnValidHighsTree()
        {
            //Arrange
            string validString = "1;2 4;5 5;6";

            List<int> expected = new List<int>() { 1, 2, 4, 5, 6 };

            //Act
            Tree actual = new Tree(validString);

            //Assert
            Assert.True(IsEgualListHighs(actual.Highs, expected));
        }

        [Fact]
        public void CodePruferByTree_ValidTree_ShouldReturnRightCode()
        {
            //Arrange
            string validString = "1;2 1;3 1;4 2;5 2;6 5;7 6;8 6;9 3;10";
            string expected = "15266213";
            Tree tree = new Tree(validString);

            //Act
            string actual = CodeMethods.CodePruferByTree(tree);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ImportStringFromCsv_ValidPath_ShouldReturnRightString()
        {
            //Arrange
            string path = "test.csv";

            var lines = new[]
            {
                new[] { 1, 2 },
                new[] { 1, 3 },
                new[] { 1, 4 },
                new[] { 2, 5 },
                new[] { 2, 6 },
                new[] { 5, 7 },
                new[] { 6, 8 },
                new[] { 6, 9 },
                new[] { 3, 10 }
            };

            try
            {
                // Запись в файл
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var item in lines)
                    {
                        writer.WriteLine($"{item[0]};{item[1]}");
                    }
                }

                string expected = "1;2 1;3 1;4 2;5 2;6 5;7 6;8 6;9 3;10";

                //Act
                string actual = CsvWorker.ImportStringFromCsv(path);

                //Assert
                Assert.Equal(expected, actual);
            }
            finally
            {
                // Удаление файла после теста (даже если тест упал)
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        
    }
}
