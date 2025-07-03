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
    }
}
