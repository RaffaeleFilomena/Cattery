using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain
{
    [TestClass]
    public sealed class TestCat
    {
        [TestMethod]
        public void TestConstructor_NameIsNull_ArgumentExpection()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id  = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat(null, "breed", Sex.FEMALE, entryDate, null, birthDate, "description",id); });
        }
        [TestMethod]
        public void TestConstructor_NameIsWhiteSpace_ArgumentExpection()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("", "breed", Sex.FEMALE, entryDate, null, birthDate, "description", id); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectName_CorrectConstructor()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Cat c = new Cat("Micia", "breed", Sex.FEMALE, entryDate, null, birthDate, "description", id);
            Assert.AreEqual("Micia", c.Name);
        }
        [TestMethod]
        public void TestConstructor_WithBreedIsNull_ArgumentExpection()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", null, Sex.FEMALE, entryDate, null, birthDate, "description", id); });
        }
        [TestMethod]
        public void TestConstructor_BreedIsWhiteSpace_ArgumentExpection()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", "", Sex.FEMALE, entryDate, null, birthDate, "description", id); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectBreed_CorrectConstructor()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "description", id);
            Assert.AreEqual("Tigrato", c.Breed);
        }
        [TestMethod]
        public void TestConstructor_CatIsMale_CorrectConstructor()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Cat c = new Cat("Micio", "Tigrato", Sex.MALE, entryDate, null, birthDate, "description", id);
            Assert.AreEqual(Sex.MALE, c.Sex);
        }
        [TestMethod]
        public void TestConstructor_CatIsFemale_CorrectConstructor()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "description", id);
            Assert.AreEqual(Sex.FEMALE, c.Sex);
        }
        [TestMethod]
        public void TestCostructor_BirthDateInFuture_ArgumentException()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = DateOnly.FromDateTime(DateTime.Now.AddDays(10));
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "description", id); });
        }
        [TestMethod]
        public void TestCostructor_EntryDateBeforeBirthDate_ArgumentException()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2024, 1, 10);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "description", id); });
        }
        public void TestCostructor_ReleaseDateBeforeBirthDate_ArgumentException()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            DateOnly releaseDate = new DateOnly(2021, 1, 1);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, releaseDate, birthDate, "description", id); });
        }
        public void TestCostructor_ReleaseDateBeforeEntryDate_ArgumentException()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            DateOnly releaseDate = new DateOnly(2022, 6, 1);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, releaseDate, birthDate, "description", id); });
        }
        [TestMethod]
        public void TestConstructor_DescriptionIsNull_ArgumentExpection()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, null, id); });
        }
        [TestMethod]
        public void TestConstructor_DescriptionIsWhiteSpace_ArgumentExpection()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "", id); });
        }
        [TestMethod]
        public void TestConstructor_WithCorrectDescription_CorrectConstructor()
        {
            DateOnly entryDate = new DateOnly(2023, 1, 1);
            DateOnly birthDate = new DateOnly(2022, 1, 1);
            ID id = new ID(birthDate);
            Cat c = new Cat("Micia", "Tigrato", Sex.FEMALE, entryDate, null, birthDate, "A very friendly cat", id);
            Assert.AreEqual("A very friendly cat", c.Description);
        }
    }
}
