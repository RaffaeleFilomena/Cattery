using Domain.Model.ValueObjects;

namespace TestDomain
{
    [TestClass]
    public sealed class TestEmail
    {
        [TestMethod]
        public void TestConstructor_EmailIsNull_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { Email e = new Email(null); });
        }
        [TestMethod]
        public void TestConstructor_EmailIsWhiteSpace_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { Email e = new Email(""); });
        }
        [TestMethod]
        public void TestConstructor_EmailWithoutAtSymbol_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { Email e = new Email("invalidemail.com"); });
        }
        [TestMethod]
        public void TestConstructor_EmailWithoutMail_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { Email e = new Email("mail"); });

        }
        
        [TestMethod]
        public void TestConstructor_EmailWithoutDotCom_ArgumentExpection()
        {
            Assert.ThrowsException<ArgumentException>(() => { Email e = new Email(".com"); });

        }
        [TestMethod]
        public void TestConstructor_WithCorrectEmail_CorrectConstructor()
        {
            Email e = new Email("valid@gmail.com");
            Assert.AreEqual("valid@gmail.com",e.Value);
        }

    }
}
