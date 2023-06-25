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
            mock = null;
        }

        ///     Output : 
        ///     [Construct]Account(ICalculate)
        ///     [Method Call] Account : GenerateTenPercentInterest
        ///     [Method Call] Account : MachineBroken
        ///     
        ///     Therefore : We know
        ///     1.  Global parameters and constructs are not enforced when using interface mocking.
        ///     2.  The method without mock will execute the original function 
        ///         when mock self class is used and the parameter of CallBase is true.
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
            // The method of MeetThief will not be executed on Account
            const int thiefFriendly = 1;
            account.Setup(x => x.MeetThief()).Returns(thiefFriendly);

            // The method of FixMachine must be can override.
            // The method of FixMachine will not be executed on Account
            account.Protected().Setup<int>("FixMachine").Returns(money);

            // It.IsAny can only be used in public or internal.
            // If you use It.IsAny in Protected(), it will only be regarded as the default value of the type
            //account.Protected().Setup<int>("MachineGotVirus", It.IsAny<double>()).Returns(money);

            // The method of MachineGotVirus must be can override.
            // The method of MachineGotVirus will not be executed on Account
            // If you use Protected(), you must use ItExpr.IsAny to execute normally.
            account.Protected().Setup<int>("MachineGotVirus", ItExpr.IsAny<double>()).Returns(money);

            //Act
            account.Object.GenerateTenPercentInterest();

            //Assert
            Assert.AreEqual(money, account.Object.Money);

            account.Verify<int>(x => x.MeetThief(), Times.Once());
            //account.Protected().Verify<int>("MachineGotVirus", Times.Once(),It.IsAny<double>());//error
            account.Protected().Verify<int>("MachineGotVirus", Times.Once(), ItExpr.IsAny<double>());// success
        }
    }
}