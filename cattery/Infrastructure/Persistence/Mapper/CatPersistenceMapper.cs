using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Persistence.Dto;

namespace Infrastructure.Persistence.Mapper
{
    internal static class CatPersistenceMapper
    {
        public static CatPersistenceDto ToPersistenceDto(this Cat cat)
        {
            return new CatPersistenceDto(
                cat.Name,
                cat.Breed,
                cat.Sex,
                cat.EntryDate,
                cat.ReleaseDate,
                cat.BirthDate,
                cat.Description,
                cat.ID
            );
        }
        public static Cat ToEntity(this CatPersistenceDto dto)
        {
            return new Cat(
                dto.Name,
                dto.Breed,
                dto.Sex,
                dto.EntryDate,
                dto.ReleaseDate,
                dto.BirthDate,
                dto.Description,
                dto.ID
            );
        }
    }
}
