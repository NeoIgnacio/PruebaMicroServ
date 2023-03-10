using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace PruebaMS.Domain.Entities
{
    public class Cliente : Persona
    {
        public int Id { get; set; }
        public string? Contrasenia { get; set; }
        public bool Estado { get; set; }

        public Cliente()
        {
            Id = 0;
            Nombre = "";
            Genero = "";
            Edad = 0;
            Identificacion = "";
            Direccion = "";
            Telefono = "";
            Contrasenia = "";
            Estado = true;
        }

        public Cliente(int id, string nombre, string genero, int edad, string identificacion, string direccion, string telefono, string contrasenia, bool estado)
        {
            Id = id;
            Nombre = nombre;
            Genero = genero;
            Edad = edad;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Contrasenia = contrasenia;
            Estado = estado;
        }

        public Cliente(string nombre, string genero, int edad, string identificacion, string direccion, string telefono, string contrasenia, bool estado)
        {
            Nombre = nombre;
            Genero = genero;
            Edad = edad;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Contrasenia = contrasenia;
            Estado = estado;
        }
    }
}