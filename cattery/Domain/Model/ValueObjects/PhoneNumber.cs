using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; }
        public PhoneNumber(string value) 
        { 
            if(string.IsNullOrWhiteSpace(value) || value.Count()<10 || value.Count()>10)
                throw new ArgumentException("phone number not valid");
            Value = value;
        }
    }
}
