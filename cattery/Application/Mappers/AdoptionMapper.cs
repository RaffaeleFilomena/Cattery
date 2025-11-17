using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Application.Dto;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToEntity(this AdoptionDto adoptionDto)
        {
            return new Adoption
           (
                adoptionDto.Cat.ToEntity(),
                adoptionDto.AdoptionDate,
                adoptionDto.Adopter.ToEntity()
           );
        }
        public static AdoptionDto ToDto(this Adoption adoption)
        {
            return new AdoptionDto(
                adoption.Cat.ToDto(),
                adoption.AdoptionDate,
                adoption.Adopter.ToDto()
            );
        }
    }
}
