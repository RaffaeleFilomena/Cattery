using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Persistence.Dto;

namespace Infrastructure.Persistence.Mapper
{
    internal static class AdoptionPersistenceMapper
    {
        public static AdoptionPersistenceDto ToPersistenceDto(this Adoption adoption)
        {
            return new AdoptionPersistenceDto(
                adoption.Cat.ID,
                adoption.Adopter.FC,
                adoption.AdoptionDate
            );
        }
        public static Adoption ToEntity(this AdoptionPersistenceDto dto, Cat cat, Adopter adopter)
        {

            return new Adoption(
                cat,
                dto.AdoptionDate,
                adopter
            );
        }
    }
}
