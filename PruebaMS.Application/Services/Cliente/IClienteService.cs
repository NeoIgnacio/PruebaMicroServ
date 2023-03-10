using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace PruebaMS.Application.Services.Cliente
{
    public interface IClienteService
    {
        Task<List<ClienteResult>> GetAll();
        Task<ClienteResult> GetById(int id);
        Task<ClienteResult> Create(string Nombre,
                string Genero,
                int Edad,
                string Identificacion,
                string Direccion,
                string Telefono,
                string Contrasenia,
                bool Estado
            );
        Task<ClienteResult> Update(int id,
                string Nombre,
                string Genero,
                int Edad,
                string Identificacion,
                string Direccion,
                string Telefono,
                string Contrasenia,
                bool Estado
            );
        Task<ClienteResult> Delete(int id);
    }
}
