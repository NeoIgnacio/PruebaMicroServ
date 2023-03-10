using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace PruebaMS.Contracts.Cliente
{
    public record ClienteResponse(
        int Id,
        string? Nombre,
        string? Genero,
        int Edad,
        string? Identificacion,
        string? Direccion,
        string? Telefono,
        string? Contrasenia,
        bool Estado);
}
