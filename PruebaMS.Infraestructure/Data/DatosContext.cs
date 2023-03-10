using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaMS.Domain.Entities;

namespace PruebaMS.Infrastructure.Data
{
    public class DatosContext : DbContext
    {
        public DatosContext(DbContextOptions<DatosContext> options): base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }

    }
}
