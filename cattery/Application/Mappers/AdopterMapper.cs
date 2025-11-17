using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class  AdopterMapper
    {
        public static Adopter ToEntity(this AdopterDto adopterDto)
        {
            return new Adopter
            (
                adopterDto.FC,
                adopterDto.Name,
                adopterDto.Surname,
                new Email(adopterDto.Email),
                new PhoneNumber(adopterDto.phoneNumber),
                adopterDto.Address,
                adopterDto.CAP,
                adopterDto.City
            );
        }
        public static AdopterDto ToDto(this Adopter adopter)
        {
            return new AdopterDto(
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
    }
}
