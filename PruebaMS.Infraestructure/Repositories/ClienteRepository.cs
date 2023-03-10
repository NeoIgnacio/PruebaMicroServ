using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
//using System.Text;
//using System.Threading.Tasks;
using PruebaMS.Application.Interfaces;
using PruebaMS.Domain.Entities;
using PruebaMS.Infrastructure.Data;

namespace PruebaMS.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public DatosContext _context;
        public ClienteRepository(DatosContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Cliente>> GetAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            Cliente? res = await _context.Cliente.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con un cliente registrado");
            return res;
        }

        public async Task<Cliente> Create(string Nombre, string Genero, int Edad,
            string Identificacion, string Direccion, string Telefono, string Contrasenia, bool Estado)
        {
            Cliente cliente = new Cliente(Nombre, Genero, Edad, Identificacion,
                Direccion, Telefono, Contrasenia, Estado);
            var res = await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Cliente> Update(int id, string Nombre, string Genero, int Edad,
            string Identificacion, string Direccion, string Telefono, string Contrasenia, bool Estado)
        {
            Cliente? res = await _context.Cliente.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con un cliente registrado");
            res.Nombre = Nombre;
            res.Genero = Genero;
            res.Edad = Edad;
            res.Identificacion = Identificacion;
            res.Direccion = Direccion;
            res.Telefono = Telefono;
            res.Contrasenia = Contrasenia;
            res.Estado = Estado;
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Cliente> Delete(int id)
        {
            Cliente? res = await _context.Cliente.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con un cliente registrado");
            //_context.Remove(res); // Borrado fisico
            res.Estado = false; // Borrado logico
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
