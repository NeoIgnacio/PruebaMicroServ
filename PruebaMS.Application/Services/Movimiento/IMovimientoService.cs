using System;
using System.Collections.Generic;
using System.Linq;
using PruebaMS.Application.Services.Movimiento;

namespace PruebaMS.Application.Services.Movimiento
{
    public interface IMovimientoService
    {
        Task<List<MovimientoResult>> GetAll();
        Task<MovimientoResult> GetById(int id);
        Task<MovimientoResult> Create(int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor); //, decimal Saldo, bool Estado);
        Task<MovimientoResult> Update(int id, int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor, decimal Saldo, bool Estado);
        Task<MovimientoResult> Delete(int id);
        Task<List<ReporteResult>> ReporteFechas(DateTime inicio, DateTime fin);
    }
}
