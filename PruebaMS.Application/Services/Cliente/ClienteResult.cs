using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace PruebaMS.Application.Services.Cliente
{
    public record ClienteResult(
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
