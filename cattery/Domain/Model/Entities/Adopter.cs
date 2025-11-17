using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public record Adopter
    {
        private string _fc;
        public string FC
        {
            get { return _fc; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException("FC invalid"); _fc = value;
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("address invalid"); _address = value;
            }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("city invalid"); _city = value;
            }
        }
        private string _cap;
        public string CAP
        {
            get { return _cap; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("CAP invalid"); _cap = value;
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("name invalid"); _name = value; }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("name invalid"); _surname = value; }
        }
        public Email Email;
        public PhoneNumber PhoneNumber;
        public Adopter(string fc,string name,string surname,Email email, PhoneNumber phoneNumber,string address,string cap,string city)
        {
            FC = fc;
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            CAP = cap;
            City = city;
        }
        
        public override int GetHashCode()
        {
            return FC.GetHashCode();
        }
    }
}
