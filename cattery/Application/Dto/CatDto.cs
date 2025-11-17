using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record CatDto(
        string Name,
        string Breed,
        Sex Sex,
        DateOnly EntryDate,
        DateOnly? ReleaseDate, 
        DateOnly BirthDate, 
        string Description,
        string ID
    );
    
        
    
}
