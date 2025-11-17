using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Persistence.Dto;
using Application.Mappers;
using Infrastructure.Persistence.Mapper;

namespace Infrastructure.Persistence.Repositories
{
    public class JsonAdoptionRepo : IAdoptionRepo
    {
        private readonly string _filePath = "adopter.json";
        private readonly Dictionary<string, Adoption> _cache = new(StringComparer.OrdinalIgnoreCase);
        private bool _initialized = false;
        private IAdopterRepo _adopterRepo;
        private ICatRepo _catRepo;
        public JsonAdoptionRepo(ICatRepo catRepo, IAdopterRepo adopterRepo) { 
            _adopterRepo = adopterRepo;
            _catRepo = catRepo;
        }
        private void EnsureLoaded()
        {
            if (_initialized) return;

            if (!File.Exists(_filePath))
            {
                _initialized = true;
                return;
            }
            var json = File.ReadAllText(_filePath);
            var dtos = JsonSerializer.Deserialize<List<AdoptionPersistenceDto>>(json) ?? new List<AdoptionPersistenceDto>();

            foreach (var dto in dtos)
            {
                Cat cat = _catRepo.GetByID(dto.ID);
                Adopter adopter = _adopterRepo.GetByFCAdopter(dto.FC);
                Adoption adoption = dto.ToEntity(cat, adopter);
                _cache[cat.ID] = adoption;
            }

            _initialized = true;
        }
        public void Add(Adoption adoption)
        {
            EnsureLoaded();
            if (_cache.ContainsKey(adoption.Cat.ID))
                throw new InvalidOperationException($"Adoption '{adoption.Cat.ID}' already exists.");
            _cache[adoption.Cat.ID] = adoption;
            SaveToFile();
        }
               
        public void Remove(Adoption adoption)
        {
            EnsureLoaded();
            if (!_cache.Remove(adoption.Cat.ID))
                throw new InvalidOperationException($"Adoption '{adoption.Cat.ID}' not found.");
            SaveToFile();
        }

        public IEnumerable<Adoption> GetAll()
        {
            EnsureLoaded();
            SaveToFile();
            return _cache.Values;
        }

        public Adoption? GetAdoptionsByCatID(string catId)
        {
            EnsureLoaded();
            Adoption? adoption;
            _cache.TryGetValue(catId, out adoption);
            SaveToFile();
            return adoption;
        }
        private void SaveToFile()
        {
            var dtos = _cache.Values.Select(a => a.ToPersistenceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
