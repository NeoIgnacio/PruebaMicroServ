using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaMS.Contracts.Movimiento
{
    public record MovimientoResponse(
        int Id,
        int CuentaId,
        DateTime Fecha,
        string? Tipo,
        decimal Valor,
        decimal Saldo,
        bool Estado);
}
