using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain
{
    [TestClass]
    public sealed class TestAdopter
    {
        [TestMethod]
        public void TestConstructor_FCIsNull_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter(null, "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli"); });
        }
        public void TestConstructor_FCIsWhiteSpace_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter("", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli"); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectFC_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli");
            Assert.AreEqual("Federico", a.Name);
        }

        [TestMethod]
        public void TestConstructor_NameIsNull_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter("345457",null,"Foschi",email,phoneNumber,"via Napoleone","47030","San Mauro Pascoli"); });
        }
        [TestMethod]
        public void TestConstructor_NameIsWhiteSpace_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter("345457","","Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli"); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectName_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457","Federico","Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli");
            Assert.AreEqual("Federico", a.Name);
        }
        [TestMethod]
        public void TestConstructor_SurnameIsNull_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter("345457","Federico",null, email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli"); });
        }
        [TestMethod]
        public void TestConstructor_SurnameIsWhiteSpace_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter("345457","Federico","", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli"); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectSurname_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457","Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli");
            Assert.AreEqual("Foschi", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_AddressIsNull_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber,null, "47030", "San Mauro Pascoli"); });
        }
        [TestMethod]
        public void TestConstructor_AddressIsWhiteSpace_ArgumentExpection()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Assert.ThrowsException<ArgumentException>(() => { Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "", "47030", "San Mauro Pascoli"); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectAddress_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli");
            Assert.AreEqual("Foschi", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_CAPIsNull_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", null, "San Mauro Pascoli");
            Assert.AreEqual("Foschi", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_CAPIsWhiteSpace_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "", "San Mauro Pascoli");
            Assert.AreEqual("Foschi", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_WithCorrectCAP_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli");
            Assert.AreEqual("Foschi", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_CityIsNull_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", null);
            Assert.AreEqual("Foschi", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_CityIsWhiteSpace_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "");
            Assert.AreEqual("Foschi", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_WithCorrectCity_CorrectConstructor()
        {
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("345457", "Federico", "Foschi", email, phoneNumber, "via Napoleone", "47030", "San Mauro Pascoli");
            Assert.AreEqual("Foschi", a.Surname);
        }


    }
}
