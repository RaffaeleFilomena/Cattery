using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Adoption
    {
        public Cat Cat {  get; private set; }
        private DateOnly? _adoptionDate;
        public DateOnly? AdoptionDate
        {
            get { return _adoptionDate; }
            private set 
            {
                if(value != null)
                {
                    if (value < Cat.EntryDate) throw new ArgumentException("adoption date cannot be before entry date");
                    if (value < Cat.BirthDate) throw new ArgumentException("adoption date cannot be before birth date");
                }
                _adoptionDate = value;
            }
        }
        public Adopter Adopter { get; private set; }
        public Adoption(Cat cat, DateOnly? adoptionDate, Adopter adopter) 
        {
            Cat = cat;
            AdoptionDate = adoptionDate;
            Adopter = adopter;
        }
    }
}
