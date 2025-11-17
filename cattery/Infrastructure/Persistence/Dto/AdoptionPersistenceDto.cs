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
    public record AdoptionPersistenceDto(
        string ID,
        string FC,
        DateOnly? AdoptionDate
    );
    
}
