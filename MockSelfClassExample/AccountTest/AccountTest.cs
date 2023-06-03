using System;
using NUnit.Framework;
using Moq;
using Moq.Protected;

namespace Account.Test
{
    [TestFixture]
    public class AccountTest
    {
        Mock<ICalculate> mock;

        [OneTimeSetUp]
        public void SetUp()
        {
            mock = new Mock<ICalculate>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Account_GenerateTenPercentInterest_Should_Success([Random(1)] int money)
        {
            //Arrange
            mock.Setup(x => x.GetPercent(It.IsAny<int>(), It.IsAny<double>())).Returns(100);
            mock.Setup(x => x.Sum(It.IsAny<int>(), It.IsAny<int>())).Returns(1000);


            /*
             * CallBase, when initialized during a mock construction, 
             * is used to specify whether the base class virtual implementation will be invoked 
             * for mocked dependencies if no setup is matched. The default value is false. 
             * This is useful when mocking HTML/web controls of the System.Web namespace:
             */
            var account = new Mock<Account>(mock.Object) { CallBase =true};

            // The method of MeetThief must be can override.
            const int noMoney = 0;
            account.Setup(x => x.MeetThief()).Returns(noMoney);
            // The method of MachineBroken must be can override.
            account.Protected().Setup<int>("MachineBroken").Returns(money); 

            //act
            account.Object.GenerateTenPercentInterest();

            //assert
            Assert.AreEqual(money, account.Object.Money);
        }
    }
}