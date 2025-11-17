using Application.Dto;
using Application.Interfaces;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Persistence.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastructure.Persistence.Mapper;
using Application.Mappers;


namespace Infrastructure.Persistence.Repositories
{
    public class JsonCatRepo: ICatRepo
    {
        private readonly string _filePath = "cat.json";
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
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
            var dtos = JsonSerializer.Deserialize<List<CatPersistenceDto>>(json) ?? new List<CatPersistenceDto>();

            foreach (var dto in dtos)
            {

                Cat cat = dto.ToEntity();
                _cache[cat.Name] = cat;
            }

            _initialized = true;
        }
        public void Add(Cat cat)
        {
            EnsureLoaded();
            if (_cache.ContainsKey(cat.ID))
                throw new InvalidOperationException($"Cat '{cat.ID}' already exists.");
            _cache[cat.ID] = cat;
            SaveToFile();
        }


        public void Remove(Cat cat)
        {
            EnsureLoaded();
            if (!_cache.Remove(cat.ID))
                throw new InvalidOperationException($"Cat '{cat.ID}' not found.");
            SaveToFile();
        }

        public Cat? GetByID(string id)
        {
            EnsureLoaded();
            Cat? cat;
            _cache.TryGetValue(id, out cat);
            SaveToFile();
            return cat;
        }
        public IEnumerable<Cat> GetAll()
        {
            EnsureLoaded();
            SaveToFile();
            return _cache.Values;
        }
        private void SaveToFile()
        {
            var dtos = _cache.Values.Select(a => a.ToPersistenceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
