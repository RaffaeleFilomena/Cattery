using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CatService
    {
        private readonly ICatRepo _repository;
        public CatService(ICatRepo repository)
        {
            _repository = repository;
        }
        public void CreateCat(CatDto catDto)
        {
            if (string.IsNullOrEmpty(catDto.Name) || string.IsNullOrEmpty(catDto.Breed)) throw new ArgumentException("Invalid cat");
            if (catDto.ReleaseDate != null && catDto.EntryDate> catDto.ReleaseDate) throw new ArgumentException("Invalid arrival date");
            if (catDto.ReleaseDate == null && catDto.BirthDate.Year < 1) throw new ArgumentException("Invalid probably year");
            var existing = _repository.GetByID(catDto.ID);
            if (existing != null)
                throw new InvalidOperationException($"This cat already exist.");
            Cat cat = catDto.ToEntity();
            _repository.Add(cat);
        }
        public List<CatDto> ViewAll()
        {
            List<CatDto> dtos = new List<CatDto>();

            foreach (Cat c in _repository.GetAll())
            {
                dtos.Add(c.ToDto());
            }
            return dtos;
        }
    }
}
