using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Application.Services.Cuenta
{
    public interface ICuentaService
    {
        Task<List<CuentaResult>> GetAll();
        Task<CuentaResult> GetById(int id);
        Task<CuentaResult> Create(int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado);
        Task<CuentaResult> Update(int id, int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado);
        Task<CuentaResult> Delete(int id);
    }
}
