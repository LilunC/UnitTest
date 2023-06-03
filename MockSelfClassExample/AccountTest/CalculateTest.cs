using NUnit.Framework;

namespace Account.Test
{
    [TestFixture]
    class CalculateTest
    {
        private ICalculate _calculate;

        [OneTimeSetUp]
        public void SetUp()
        {
            _calculate = new Calculate();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _calculate = null;
        }

        [Test]
        public void Sum_Should_Success()
        {
            //Arrange
            int augend = 2;
            int addend = 3;
            int expectedResult = 5;

            //act
            var result = _calculate.Sum(augend, addend);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetPercent_Should_Success([Random(1)] int money)
        {
            //Arrange
            int value = 10000;
            double percent = 0.3d;
            int expectedResult = 3000;

            //act
            var result = _calculate.GetPercent(value, percent);

            //assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}