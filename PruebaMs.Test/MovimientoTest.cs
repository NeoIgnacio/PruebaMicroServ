using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PruebaMS.API;
using PruebaMS.API.Controllers;
using PruebaMS.Application.Interfaces;
using PruebaMS.Application.Services.Movimiento;
using PruebaMS.Infrastructure.Data;
using PruebaMS.Infrastructure.Repositories;

namespace PruebaMS.Test
{
    public class MovimientoTest
    {
        private IMovimientoService _movimientoService;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DatosContext> options = new DbContextOptionsBuilder<DatosContext>()
                .UseSqlServer("Server=tcp:192.168.1.6,1433; Encrypt=False; Initial Catalog=PruebaMicroServ; User Id=sa; Password=Jo$e12345678;")
                .Options;
            DatosContext context = new DatosContext(options);
            IMovimientoRepository movimientoRepository = new MovimientoRepository(context);
            _movimientoService = new MovimientoService(movimientoRepository);
        }

        [Test]
        public async Task GetAllTest()
        {
            MovimientoController movimientoController = new MovimientoController(_movimientoService);

            var resultado = await movimientoController.Movimientos();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is OkObjectResult);
            OkObjectResult okResult = (OkObjectResult)resultado;
            Assert.IsNotNull(okResult.Value);
        }

        [Test]
        public async Task GetByIdTest()
        {
            MovimientoController movimientoController = new MovimientoController(_movimientoService);

            var resultado = await movimientoController.Movimiento(1);
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is OkObjectResult);
            OkObjectResult okResult = (OkObjectResult)resultado;
            Assert.IsNotNull(okResult.Value);
        }
    }
}
