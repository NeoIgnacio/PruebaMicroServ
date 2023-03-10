using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Contracts.Movimiento
{
    public record ReporteResponse(
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
