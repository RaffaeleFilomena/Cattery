using Domain.Model.ValueObjects;

namespace TestDomain
{
    [TestClass]
    public sealed class TestPhone
    {
        [TestMethod]
        public void TestConstructor_PhoneIsNull_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { PhoneNumber p = new PhoneNumber(null); });
        }
        [TestMethod]
        public void TestConstructor_PhoneIsWhiteSpace_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { PhoneNumber p = new PhoneNumber(""); });
        }
        [TestMethod]
        public void TestConstructor_PhoneWithLessThan10_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { PhoneNumber p = new PhoneNumber("123456789"); });
        }
        [TestMethod]
        public void TestConstructor_PhoneWithMoreThan10_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { PhoneNumber p = new PhoneNumber("12345678901"); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectPhone_CorrectConstructor()
        {
            PhoneNumber p = new PhoneNumber("1234567890");
            Assert.AreEqual("1234567890", p.Value);
        }
    }
}
