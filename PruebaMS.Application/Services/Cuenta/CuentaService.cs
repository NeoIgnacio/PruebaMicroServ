using System;
using System.Collections.Generic;
using System.Linq;
using PruebaMS.Application.Interfaces;
using PruebaMS.Domain.Entities;

namespace PruebaMS.Application.Services.Cuenta
{
    public class CuentaService : ICuentaService
    {
        public readonly ICuentaRepository _cuentaRepository;
        public CuentaService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public async Task<List<CuentaResult>> GetAll()
        {
            var res = await _cuentaRepository.GetAllAsync();
            var response = new List<CuentaResult>();
            foreach (var c in res)
            {
                response.Add(new CuentaResult(c.Id, c.ClienteId, c.Numero, c.Tipo, c.SaldoInicial, c.Estado));
            }
            return response;
        }

        public async Task<CuentaResult> GetById(int id)
        {
            var res = await _cuentaRepository.GetByIdAsync(id);
            return new CuentaResult(res.Id, res.ClienteId, res.Numero, res.Tipo, res.SaldoInicial, res.Estado);
        }

        public async Task<CuentaResult> Create(int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado)
        {
            var res = await _cuentaRepository.Create(ClienteId, Numero, Tipo, Saldo, Estado);
            return new CuentaResult(res.Id, ClienteId, Numero, Tipo, Saldo, Estado);
        }

        public async Task<CuentaResult> Update(int id, int ClienteId, string? Numero, string? Tipo, decimal Saldo, bool Estado)
        {
            var res = await _cuentaRepository.Update(id, ClienteId, Numero, Tipo, Saldo, Estado);
            return new CuentaResult(id, ClienteId, Numero, Tipo, Saldo, Estado);
        }

        public async Task<CuentaResult> Delete(int id)
        {
            var res = await _cuentaRepository.Delete(id);
            return new CuentaResult(res.Id, res.ClienteId, res.Numero, res.Tipo, res.SaldoInicial, res.Estado);
        }
    }
}
