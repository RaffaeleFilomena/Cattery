using Infrastructure.Persistence.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Infrastructure.Persistence.Mapper
{
    internal static class AdopterPersistenceMapper
    {
        public static AdopterPersistenceDto ToPersistenceDto(this Adopter adopter)
        {
            return new AdopterPersistenceDto(
                adopter.FC,
                adopter.Name,
                adopter.Surname,
                adopter.Email.Value,
                adopter.PhoneNumber.Value,
                adopter.Address,
                adopter.CAP,
                adopter.City

            );
        }
        public static Adopter ToEntity(this AdopterPersistenceDto dto)
        {
            return new Adopter(
                dto.FC,
                dto.Name,
                dto.Surname,
                new Email(dto.Email),
                new PhoneNumber(dto.phoneNumber),
                dto.Address,
                dto.CAP,
                dto.City
            );
        }
    }
}
