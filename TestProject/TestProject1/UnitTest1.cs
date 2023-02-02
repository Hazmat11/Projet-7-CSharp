using Projet_7.src;

namespace TestProject1
{
    public class TestCombat
    {
        [Test]
        [TestCase(100,100,200)]
        public void Addition(int a, int b, int expected)
        {
            Object
            int result = a + b;
            Assert.That(result, Is.EqualTo(expected));
        }
    }

}
