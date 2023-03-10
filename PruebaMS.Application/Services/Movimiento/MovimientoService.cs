using System;
using System.Collections.Generic;
using System.Linq;
using PruebaMS.Application.Interfaces;

namespace PruebaMS.Application.Services.Movimiento
{
    public class MovimientoService : IMovimientoService
    {
        public readonly IMovimientoRepository _movimientoRepository;
        public MovimientoService(IMovimientoRepository MovimientoRepository)
        {
            _movimientoRepository = MovimientoRepository;
        }

        public async Task<List<MovimientoResult>> GetAll()
        {
            var res = await _movimientoRepository.GetAllAsync();
            var response = new List<MovimientoResult>();
            foreach (var c in res)
            {
                response.Add(new MovimientoResult(c.Id, c.CuentaId, c.Fecha, c.Tipo, c.Valor, c.Saldo, c.Estado));
            }
            return response;
        }

        public async Task<MovimientoResult> GetById(int id)
        {
            var res = await _movimientoRepository.GetByIdAsync(id);
            return new MovimientoResult(res.Id, res.CuentaId, res.Fecha, res.Tipo, res.Valor, res.Saldo, res.Estado);
        }

        public async Task<MovimientoResult> Create(int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor) //, decimal Saldo, bool Estado)
        {
            string tipo = (Tipo ?? "").ToUpper();
            if (!(tipo == "DEPOSITO" || tipo == "RETIRO"))
            {
                throw new Exception("Los tipos de movimientos permitido son DEPOSITO o RETIRO");
            }
            if (Valor > 0 && tipo == "RETIRO")
            {
                Valor *= -1;
            }

            decimal saldo = await _movimientoRepository.GetCuentaSaldoAsync(CuentaId);
            saldo += Valor;
            if (Math.Abs(Valor) > saldo && tipo == "RETIRO")
            {
                throw new Exception("Saldo no disponible");
            }

            var res = await _movimientoRepository.Create(CuentaId, Fecha, Tipo, Valor, saldo, true);
            return new MovimientoResult(res.Id, res.CuentaId, res.Fecha, res.Tipo, res.Valor, res.Saldo, res.Estado);
        }

        public async Task<MovimientoResult> Update(int id, int CuentaId, DateTime Fecha, string? Tipo,
            decimal Valor, decimal Saldo, bool Estado)
        {
            var res = await _movimientoRepository.Update(id, CuentaId, Fecha, Tipo, Valor, Saldo, Estado);
            return new MovimientoResult(res.Id, res.CuentaId, res.Fecha, res.Tipo, res.Valor, res.Saldo, res.Estado);
        }

        public async Task<MovimientoResult> Delete(int id)
        {
            var res = await _movimientoRepository.Delete(id);
            return new MovimientoResult(res.Id, res.CuentaId, res.Fecha, res.Tipo, res.Valor, res.Saldo, res.Estado);
        }

        public async Task<List<ReporteResult>> ReporteFechas(DateTime inicio, DateTime fin)
        {
            var res = await _movimientoRepository.ReporteFechas(inicio, fin);
            var response = new List<ReporteResult>();
            foreach (var c in res)
            {
                response.Add(new ReporteResult(c.Fecha, c.Cliente, c.NumeroCuenta, c.Tipo,
                    c.SaldoInicial, c.Estado, c.Movimiento, c.SaldoDisponible ));
            }
            return response;
        }
    }
}
