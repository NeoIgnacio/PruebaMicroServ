using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Domain.Entities
{
    public class Reporte
    {
        public DateTime Fecha { get; set; }
        public string? Cliente { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }

        public Reporte(DateTime Fecha, string? Cliente, string? NumeroCuenta, string? Tipo,
            decimal SaldoInicial, bool Estado, decimal Movimiento, decimal SaldoDisponible)
        {
            this.Fecha = Fecha;
            this.Cliente = Cliente;
            this.NumeroCuenta = NumeroCuenta;
            this.Tipo = Tipo;
            this.SaldoInicial = SaldoInicial;
            this.Estado = Estado;
            this.Movimiento = Movimiento;
            this.SaldoDisponible = SaldoDisponible;
        }
    }
}
