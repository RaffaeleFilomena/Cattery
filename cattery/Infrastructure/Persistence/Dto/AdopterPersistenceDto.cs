using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Application.Dto;

namespace Infrastructure.Persistence.Dto
{
    public record AdopterPersistenceDto(
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
