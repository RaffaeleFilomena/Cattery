using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
namespace Application.UseCases
{
    public class AdopterService
    {
        private readonly IAdopterRepo _repository;

        //Dependency Injection
        public AdopterService(IAdopterRepo repository)
        {
            _repository = repository;
        }
        public void CreateAdopter(AdopterDto adopterDto)
        {
            if (string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.Surname) || string.IsNullOrEmpty(adopterDto.Address) || string.IsNullOrEmpty(adopterDto.City)) throw new ArgumentException("Invalid adopter");

            var existing = _repository.GetByFCAdopter(adopterDto.FC);
            if (existing != null)
                throw new InvalidOperationException("This adopter already exist.");        
            Adopter adopter = adopterDto.ToEntity();

            _repository.Add(adopter);
        }
        public void RemoveAdopter(AdopterDto adopterDto)
        {
            if (string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.Surname) || string.IsNullOrEmpty(adopterDto.Address) || string.IsNullOrEmpty(adopterDto.City)) throw new ArgumentException("Invalid adopter");

            var entity = _repository.GetByFCAdopter(adopterDto.FC);
            if (entity == null)
                throw new InvalidOperationException("Adopter not found.");

            _repository.Remove(entity);
        }

        public Adopter? SearchAdopterByFC(string FC)
        {
            if (string.IsNullOrWhiteSpace(FC)) throw new ArgumentException("Fiscal Code null or blank");

            Adopter? adopter = _repository.GetByFCAdopter(FC);

            return adopter;
        }
    }
}
