using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObjects;

namespace Application.Interfaces
{
    public interface ICatRepo
    {
        void Add(Cat cat);
        void Remove(Cat cat);
        Cat? GetByID(string ID);
        IEnumerable<Cat> GetAll();

    }
}
