using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using PruebaMS.Application.Interfaces;
using PruebaMS.Application.Services.Movimiento;
using PruebaMS.Domain.Entities;
using PruebaMS.Infrastructure.Data;

namespace PruebaMS.Infrastructure.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        public DatosContext _context;
        public MovimientoRepository(DatosContext context)
        {
            _context = context;
        }

        public async Task<List<Movimiento>> GetAllAsync()
        {
            return await _context.Movimiento.ToListAsync();
        }

        public async Task<Movimiento> GetByIdAsync(int id)
        {
            Movimiento? res = await _context.Movimiento.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con un movimiento registrado");
            return res;
        }

        public async Task<decimal> GetCuentaSaldoAsync(int cuentaId)
        {
            decimal saldo = 0;
            Movimiento? mov = await _context.Movimiento.Where(m => m.CuentaId == cuentaId).OrderByDescending(m => m.Fecha).FirstOrDefaultAsync();
            if (mov != null)
            {
                saldo = mov.Saldo;
            }
            else
            {
                Cuenta? cuenta = await _context.Cuenta.FindAsync(cuentaId);
                if (cuenta == null)
                {
                    throw new Exception("No existe una cuenta registrada");
                }
                saldo = cuenta.SaldoInicial;
            }
            return saldo;
        }

        public async Task<Movimiento> Create(int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor, decimal Saldo, bool Estado)
        {
            Movimiento Movimiento = new Movimiento(CuentaId, Fecha, Tipo, Valor, Saldo, Estado);
            var res = await _context.AddAsync(Movimiento);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Movimiento> Update(int id, int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor, decimal Saldo, bool Estado)
        {
            Movimiento? res = await _context.Movimiento.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con un movimiento registrado");
            res.CuentaId = CuentaId;
            res.Fecha = Fecha;
            res.Tipo = Tipo;
            res.Valor = Valor;
            res.Saldo = Saldo;
            res.Estado = Estado;
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Movimiento> Delete(int id)
        {
            Movimiento? res = await _context.Movimiento.FindAsync(id);
            if (res == null)
                throw new Exception("El id no coincide con un movimiento registrado");
            //_context.Remove(res); // Borrado fisico
            res.Estado = false; // Borrado logico
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<List<Reporte>> ReporteFechas(DateTime inicio, DateTime fin)
        {
            inicio = inicio.Date;
            fin = fin.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            return await (from m in _context.Movimiento
                          join cu in _context.Cuenta on m.CuentaId equals cu.Id
                          join cl in _context.Cliente on cu.ClienteId equals cl.Id
                          where m.Fecha >= inicio
                          && m.Fecha <= fin
                          select new Reporte(
                                m.Fecha,
                                cl.Nombre,
                                cu.Numero,
                                cu.Tipo,
                                cu.SaldoInicial,
                                m.Estado,
                                m.Valor,
                                m.Saldo
                        )).ToListAsync();
        }
    }
}
