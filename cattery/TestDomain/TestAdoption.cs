using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain
{
    [TestClass]
    public sealed class TestAdoption
    {
        [TestMethod]
        public void TestConstructorAdoption_WithAdoptionDateBeforeEntryDate_ArgumentException()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("Federico", "Foschi", email, phoneNumber);
            Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "A very friendly cat");
            DateOnly? adoptionDate = new DateOnly(2022, 6, 1);
            Assert.ThrowsException<ArgumentException>(() => { Adoption adoption = new Adoption(c, adoptionDate, a); });
        }
        [TestMethod]
        public void TestConstructorAdoption_WithAdoptionDateBeforeBirthDate_ArgumentException()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("Federico", "Foschi", email, phoneNumber);
            Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "A very friendly cat");
            DateOnly? adoptionDate = new DateOnly(2020, 6, 1);
            Assert.ThrowsException<ArgumentException>(() => { Adoption adoption = new Adoption(c, adoptionDate, a); });
        }
        [TestMethod]
        public void TestConstructorAdoption_WithCorrectParameters_CorrectConstructor()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            Email email = new Email("FedericoFoschi@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("3334445555");
            Adopter a = new Adopter("Federico", "Foschi", email, phoneNumber);
            Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "A very friendly cat");
            DateOnly? adoptionDate = new DateOnly(2023, 6, 1);
            DateOnly? expectedAdoptionDate = adoptionDate;
            Assert.AreEqual(expectedAdoptionDate,adoptionDate);
        }
    }
}
