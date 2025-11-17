using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Persistence.Dto;
using Infrastructure.Persistence.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Infrastructure.Persistence.Repositories
{
    public class JsonAdopterRepo : IAdopterRepo
    {
        private readonly string _filePath = "adopter.json";
        private readonly Dictionary<string, Adopter> _cache = new(StringComparer.OrdinalIgnoreCase);
        private bool _initialized = false;
        private void EnsureLoaded()
        {
            if (_initialized) return;

            if (!File.Exists(_filePath))
            {
                _initialized = true;
                return;
            }
            var json = File.ReadAllText(_filePath);
            var dtos = JsonSerializer.Deserialize<List<AdopterPersistenceDto>>(json) ?? new List<AdopterPersistenceDto>();

            foreach (var dto in dtos)
            {

                Adopter adopter = dto.ToEntity();
                _cache[adopter.Name] = adopter;
            }

            _initialized = true;
        }
        public void Add(Adopter adopter)
        {
            EnsureLoaded();
            if (_cache.ContainsKey(adopter.FC))
                throw new InvalidOperationException($"Adopter '{adopter.FC}' already exists.");
            _cache[adopter.Name] = adopter;
            SaveToFile();
        }


        public void Remove(Adopter adopter)
        {
            EnsureLoaded();
            if (!_cache.Remove(adopter.FC))
            throw new InvalidOperationException($"Adopter '{adopter.FC}' not found.");
            SaveToFile();
        }

        public IEnumerable<Adopter> GetAll()
        {
            EnsureLoaded();
            SaveToFile();
            return _cache.Values;
            
        }
        public Adopter? GetByFCAdopter(string fC)
        {
            EnsureLoaded();
            Adopter? adopter;
            _cache.TryGetValue(fC, out adopter);
            SaveToFile();
            return adopter;
            
        }
        private void SaveToFile()
        {
            var dtos = _cache.Values.Select(a => a.ToPersistenceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
