using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdopterDto(
        string FC,
        string Name, 
        string Surname, 
        string Email, 
        string phoneNumber,
        string Address,
        string CAP,
        string City
    );
    
    
}
