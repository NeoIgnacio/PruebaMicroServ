//using PruebaMS.Application.Common.Interfaces.Persistance;
using PruebaMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Application.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteResult>> GetAll()
        {
            var res = await _clienteRepository.GetAllAsync();
            var response = new List<ClienteResult>();
            foreach (var c in res)
            {
                response.Add(new ClienteResult(c.Id, c.Nombre, c.Genero, c.Edad, 
                    c.Identificacion, c.Direccion, c.Telefono, c.Contrasenia, c.Estado));
            }
            return response;
        }

        public async Task<ClienteResult> GetById(int id)
        {
            var res = await _clienteRepository.GetByIdAsync(id);
            return new ClienteResult(res.Id, res.Nombre, res.Genero, res.Edad,
                res.Identificacion, res.Direccion, res.Telefono, res.Contrasenia, res.Estado);
        }

        public async Task<ClienteResult> Create(string Nombre, string Genero, int Edad,
            string Identificacion, string Direccion, string Telefono, string Contrasenia, bool Estado)
        {
            var res = await _clienteRepository.Create(Nombre, Genero, Edad, Identificacion,
                Direccion, Telefono, Contrasenia, Estado);
            return new ClienteResult(res.Id, res.Nombre, res.Genero, res.Edad,
                res.Identificacion, res.Direccion, res.Telefono, res.Contrasenia, res.Estado);
        }

        public async Task<ClienteResult> Update(int id, string Nombre, string Genero, int Edad,
            string Identificacion, string Direccion, string Telefono, string Contrasenia, bool Estado)
        {
            var res = await _clienteRepository.Update(id, Nombre, Genero, Edad, Identificacion,
                Direccion, Telefono, Contrasenia, Estado);
            return new ClienteResult(res.Id, res.Nombre, res.Genero, res.Edad,
                res.Identificacion, res.Direccion, res.Telefono, res.Contrasenia, res.Estado);
        }

        public async Task<ClienteResult> Delete(int id)
        {
            var res = await _clienteRepository.Delete(id);
            return new ClienteResult(res.Id, res.Nombre, res.Genero, res.Edad,
                res.Identificacion, res.Direccion, res.Telefono, res.Contrasenia, res.Estado);
        }
    }
}
