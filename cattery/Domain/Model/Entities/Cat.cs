using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObjects;

namespace Domain.Model.Entities
{
    public class Cat
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException ( "cat doesn't have name" );_name = value; }
        }
        private string _breed;
        public string Breed
        {
            get { return _breed; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("i need breed");
                _breed = value;
            }
        }        
        public Sex Sex {  get; private set; }
        private DateOnly _entryDate;
        public DateOnly EntryDate
        {
            get { return _entryDate; }
            set 
            {   
                if (value < BirthDate) throw new ArgumentException("entry date cannot be before birth date");
                _entryDate = value;
            }
        }
        private DateOnly? _releaseDate;
        public DateOnly? ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                if (value<BirthDate || value < EntryDate) throw new ArgumentException("release date cannot be before entry date");
                _releaseDate = value;
            }
        }
        
        private DateOnly _birthDate;
        public DateOnly BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value == DateOnly.FromDateTime(DateTime.Now.AddDays(10)) || value> EntryDate) throw new ArgumentException("birth date cannot be in the future");
                _birthDate = value;
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("there is not a description");
                _description = value;
            }
        }
        public string ID { get; private set; }
        public Cat(string name, string breed, Sex sex, DateOnly entryDate, DateOnly? releaseDate,DateOnly birthDate,string description, string id)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            EntryDate = entryDate;
            ReleaseDate = releaseDate;
            BirthDate = birthDate;
            Description = description;
            ID = id;
        }

        public Cat(string name, string breed, Sex sex, DateOnly entryDate, DateOnly? releaseDate, DateOnly birthDate, string description)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            EntryDate = entryDate;
            ReleaseDate = releaseDate;
            BirthDate = birthDate;
            Description = description;
            ID = CreateId();
        }

        private string CreateId()
        {
            Random random = new Random();
            // 1. Numero random di 5 cifre
            int number = random.Next(10000, 100000);

            // 2. Prima lettera del mese di registrazione
            string firstLetterOfMonth = EntryDate.Month.ToString()[0].ToString().ToUpper();

            // 3. Anno della data di registrazione
            string year = EntryDate.Year.ToString();

            // 4. Tre lettere casuali
            string randomLetters = GenerateRandomLetters(3);

            return $"{number}{firstLetterOfMonth}{year}{randomLetters}";
        }
        private string GenerateRandomLetters(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int indexNumber = random.Next(chars.Length);
                sb.Append(chars[indexNumber]);
            }
            return sb.ToString();
        }




    }
}
