using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaMS.Application.Services.Movimiento
{
    public record MovimientoResult(
        int Id,
        int CuentaId,
        DateTime Fecha,
        string? Tipo,
        decimal Valor,
        decimal Saldo,
        bool Estado);
}
