using System;
using System.Collections.Generic;
using System.Linq;
using PruebaMS.Application.Services.Movimiento;
using PruebaMS.Domain.Entities;

namespace PruebaMS.Application.Interfaces
{
    public interface IMovimientoRepository
    {
        Task<List<Movimiento>> GetAllAsync();
        Task<Movimiento> GetByIdAsync(int id);
        Task<Movimiento> Create(int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor, decimal Saldo, bool Estado);
        Task<Movimiento> Update(int id, int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor, decimal Saldo, bool Estado);
        Task<Movimiento> Delete(int id);

        Task<decimal> GetCuentaSaldoAsync(int cuentaId);
        Task<List<Reporte>> ReporteFechas(DateTime inicio, DateTime fin);
    }
}
