using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PruebaMS.Application.Interfaces;
using PruebaMS.Domain.Entities;
using PruebaMS.Infrastructure.Data;

namespace PruebaMS.Infrastructure.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        public DatosContext _context;
        public CuentaRepository(DatosContext context)
        {
            _context = context;
        }

        public async Task<List<Cuenta>> GetAllAsync()
        {
            return await _context.Cuenta.ToListAsync();
        }

        public async Task<Cuenta> GetByIdAsync(int id)
        {
            Cuenta? res = await _context.Cuenta.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con una cuenta registrada");
            return res;
        }

        public async Task<Cuenta> Create(int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado)
        {
            Cuenta cuenta = new Cuenta(ClienteId, Numero, Tipo, Saldo, Estado);
            var res = await _context.AddAsync(cuenta);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Cuenta> Update(int id, int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado)
        {
            Cuenta? res = await _context.Cuenta.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con una cuenta registrada");
            res.ClienteId = ClienteId;
            res.Numero = Numero;
            res.Tipo = Tipo;
            res.SaldoInicial = Saldo;
            res.Estado = Estado;
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Cuenta> Delete(int id)
        {
            Cuenta? res = await _context.Cuenta.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con una cuenta registrada");
            //_context.Remove(res); // Borrado fisico
            res.Estado = false; // Borrado logico
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
