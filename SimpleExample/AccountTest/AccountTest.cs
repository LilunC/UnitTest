using System;
using NUnit.Framework;
using Moq;

namespace Account.Test
{
    [TestFixture]
    public class AccountTest
    {
        private Account account;
        Mock<ICalculate> mock;

        [OneTimeSetUp]
        public void SetUp()
        {
            mock = new Mock<ICalculate>();
            account = new Account(mock.Object);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            account = null;
        }

        [Test]
        public void Account_SetMoney_Should_Success([Random(1)] int money)
        {
            //Arrange

            //act
            account.SetMoney(money);

            //assert
            Assert.AreEqual(account.Money, money);
        }

        [Test]
        public void Account_GenerateTenPercentInterest_Should_Success([Random(1)] int money)
        {
            //Arrange
            mock.Setup(x => x.GetPercent(It.IsAny<int>(), It.IsAny<double>())).Returns(100);
            mock.Setup(x => x.Sum(It.IsAny<int>(), It.IsAny<int>())).Returns(1000);

            //act
            account.GenerateTenPercentInterest();

            //assert
            Assert.AreEqual(account.Money, 1000);
        }
    }
}