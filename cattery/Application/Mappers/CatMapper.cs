using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Application.Dto;
using System.Runtime.CompilerServices;

namespace Application.Mappers
{
    public static class CatMapper
    {
        public static Cat ToEntity(this CatDto catDto)
        {
            return new Cat
           (
                catDto.Name,
                catDto.Breed,
                catDto.Sex,
                catDto.EntryDate,
                catDto.ReleaseDate,
                catDto.BirthDate,
                catDto.Description,
                catDto.ID
           );
        }
        public static CatDto ToDto(this Cat cat)
        {
            return new CatDto(
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
    }
}
