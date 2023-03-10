using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Domain.Entities
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }

        public Movimiento(int id, int cuentaId, DateTime fecha, string? tipo, decimal valor, decimal saldo, bool estado)
        {
            Id = id;
            CuentaId = cuentaId;
            Fecha = fecha;
            Tipo = tipo;
            Valor = valor;
            Saldo = saldo;
            Estado = estado;
        }

        public Movimiento(int cuentaId, DateTime fecha, string? tipo, decimal valor, decimal saldo, bool estado)
        {
            CuentaId = cuentaId;
            Fecha = fecha;
            Tipo = tipo;
            Valor = valor;
            Saldo = saldo;
            Estado = estado;
        }
    }
}
