using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PruebaMS.API;
using PruebaMS.API.Controllers;
using PruebaMS.Application.Interfaces;
using PruebaMS.Application.Services.Cuenta;
using PruebaMS.Infrastructure.Data;
using PruebaMS.Infrastructure.Repositories;

namespace PruebaMS.Test
{
    public class CuentaTest
    {
        private ICuentaService _cuentaService;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DatosContext> options = new DbContextOptionsBuilder<DatosContext>()
                .UseSqlServer("Server=tcp:192.168.1.6,1433; Encrypt=False; Initial Catalog=PruebaMicroServ; User Id=sa; Password=Jo$e12345678;")
                .Options;
            DatosContext context = new DatosContext(options);
            ICuentaRepository cuentaRepository = new CuentaRepository(context);
            _cuentaService = new CuentaService(cuentaRepository);
        }

        [Test]
        public async Task GetAllTest()
        {
            CuentaController cuentaController = new CuentaController(_cuentaService);

            var resultado = await cuentaController.Cuentas();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is OkObjectResult);
            OkObjectResult okResult = (OkObjectResult)resultado;
            Assert.IsNotNull(okResult.Value);
        }

        [Test]
        public async Task GetByIdTest()
        {
            CuentaController cuentaController = new CuentaController(_cuentaService);

            var resultado = await cuentaController.Cuenta(1);
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is OkObjectResult);
            OkObjectResult okResult = (OkObjectResult)resultado;
            Assert.IsNotNull(okResult.Value);
        }
    }
}
