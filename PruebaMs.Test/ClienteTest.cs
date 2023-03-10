using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PruebaMS.API;
using PruebaMS.API.Controllers;
using PruebaMS.Application.Interfaces;
using PruebaMS.Application.Services.Cliente;
using PruebaMS.Infrastructure.Data;
using PruebaMS.Infrastructure.Repositories;

namespace PruebaMS.Test
{
    public class ClienteTest
    {
        private IClienteService _clienteService;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DatosContext> options = new DbContextOptionsBuilder<DatosContext>()
                .UseSqlServer("Server=tcp:192.168.1.6,1433; Encrypt=False; Initial Catalog=PruebaMicroServ; User Id=sa; Password=Jo$e12345678;")
                .Options;
            DatosContext context = new DatosContext(options);
            IClienteRepository clienteRepository = new ClienteRepository(context);
            //IClienteService clienteService = new ClienteService(clienteRepository);
            _clienteService = new ClienteService(clienteRepository);
            //ClienteController clienteController = new ClienteController(clienteService);
        }

        [Test]
        public async Task GetAllTest()
        {
            ClienteController clienteController = new ClienteController(_clienteService);
            
            var resultado = await clienteController.Clientes();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is OkObjectResult);
            OkObjectResult okResult = (OkObjectResult)resultado;
            Assert.IsNotNull(okResult.Value);
        }

        [Test]
        public async Task GetByIdTest()
        {
            ClienteController clienteController = new ClienteController(_clienteService);

            var resultado = await clienteController.Cliente(1);
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is OkObjectResult);
            OkObjectResult okResult = (OkObjectResult)resultado;
            Assert.IsNotNull(okResult.Value);
        }
    }
}