using System;
using System.Collections.Generic;
using System.Linq;
using PruebaMS.Domain.Entities;

namespace PruebaMS.Application.Interfaces
{
    public interface ICuentaRepository
    {
        Task<List<Cuenta>> GetAllAsync();
        Task<Cuenta> GetByIdAsync(int id);
        Task<Cuenta> Create(int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado);
        Task<Cuenta> Update(int id, int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado);
        Task<Cuenta> Delete(int id);
    }
}
