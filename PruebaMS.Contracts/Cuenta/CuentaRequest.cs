using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Contracts.Cuenta
{
    public record CuentaRequest(
        int Id,
        int ClienteId,
        string? Numero,
        string? Tipo,
        decimal Saldo,
        bool Estado);
}
