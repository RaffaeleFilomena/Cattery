using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface IAdopterRepo
    {
        Adopter? GetByFCAdopter(string FC);
        void Add(Adopter adopter);
        void Remove(Adopter adopter);
        IEnumerable<Adopter> GetAll();
    }
}
