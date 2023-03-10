using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMS.Domain.Entities
{
    public class Cuenta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set;}
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public Cuenta(int clienteId, string? numero, string? tipo, decimal saldoInicial, bool estado)
        {
            ClienteId = clienteId;
            Numero = numero;
            SaldoInicial = saldoInicial;
            Tipo = tipo;
            Estado = estado;
        }

        public Cuenta(int id, int clienteId, string? numero, string? tipo, decimal saldoInicial, bool estado)
        {
            Id = id;
            ClienteId = clienteId;
            Numero = numero;
            SaldoInicial = saldoInicial;
            Tipo = tipo;
            Estado = estado;
        }
    }
}
