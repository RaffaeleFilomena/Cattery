using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mappers;

namespace Application.UseCases
{
    public class AdoptionService
    {
        private readonly IAdoptionRepo _repository;
        public AdoptionService(IAdoptionRepo repository)
        {
            _repository = repository;
        }
        public void CreateAdoption(AdoptionDto adoptionDto)
        {
            if (adoptionDto.Cat == null || adoptionDto.Adopter == null || adoptionDto.AdoptionDate == default) throw new ArgumentException("Invalid adoption");

            var existingAdoptions = _repository.GetAdoptionsByCat(adoptionDto.Cat.ID);
            //controllo che non ci siano già adozioni per quel gatto non fallite! oppure controllo che il gatto sia ancora in gattile
            if (existingAdoptions.Count()>0 || existingAdoptions==null) throw new ArgumentException("Cat already adopted");


           _repository.Add(adoptionDto.ToEntity());
        }
        public void RemoveAdoption(AdoptionDto adoptionDto)
        {
            if (adoptionDto.Cat == null || adoptionDto.Adopter == null || adoptionDto.AdoptionDate == default) throw new ArgumentException("Invalid adoption");

            var adoption = _repository.GetAdoptionsByCat(adoptionDto.Cat.ID);
            if (adoption == null) throw new ArgumentException("Cat not found");

            _repository.Remove(adoptionDto.ToEntity());
            
        }
    }
}
