using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Application.Services.Movimiento
{
    public record ReporteResult(
        DateTime Fecha,
        string? Cliente,
        string? NumeroCuenta,
        string? Tipo,
        decimal SaldoInicial,
        bool Estado,
        decimal Movimiento,
        decimal SaldoDisponible
        );
}
