using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using PruebaMS.Domain.Entities;

namespace PruebaMS.Application.Interfaces
{
    public interface IClienteRepository
    {
        Task<IReadOnlyList<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> Create(string Nombre, string Genero, int Edad, string Identificacion,
            string Direccion, string Telefono, string Contrasenia, bool Estado);
        Task<Cliente> Update(int id, string Nombre, string Genero, int Edad, string Identificacion,
            string Direccion, string Telefono, string Contrasenia, bool Estado);
        Task<Cliente> Delete(int id);
    }
}
