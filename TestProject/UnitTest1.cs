global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;

namespace TestProject1
{
    public class TestCombat
    {
        [Test]
        [TestCase(100,100,200)]
        public void Addition(int a, int b, int expected)
        {
            int result = a + b;
            Assert.That(result, Is.EqualTo(expected));
        }
    }

}
