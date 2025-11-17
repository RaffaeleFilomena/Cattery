using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdoptionRepo
    {
        void Add(Adoption adoption);
        void Remove(Adoption adoption);
        IEnumerable<Adoption> GetAll();
        Adoption? GetAdoptionsByCatID(string catId);
    }
}
