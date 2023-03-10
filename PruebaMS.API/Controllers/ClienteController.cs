using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMS.Application.Services.Cliente;
using PruebaMS.Contracts.Cliente;

namespace PruebaMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Clientes()
        {
            try
            {
                var res = await _clienteService.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Cliente(int id)
        {
            try
            {
                var res = await _clienteService.GetById(id);

                var response = new ClienteResponse(
                    res.Id,
                    res.Nombre,
                    res.Genero,
                    res.Edad,
                    res.Identificacion,
                    res.Direccion,
                    res.Telefono,
                    res.Contrasenia,
                    res.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Create(ClienteRequest request)
        {
            try
            {
                ClienteResult result = await _clienteService.Create(request.Nombre,
                    request.Genero,
                    request.Edad,
                    request.Identificacion,
                    request.Direccion,
                    request.Telefono,
                    request.Contrasenia,
                    request.Estado);

                ClienteResponse response = new ClienteResponse(result.Id,
                    result.Nombre,
                    result.Genero,
                    result.Edad,
                    result.Identificacion,
                    result.Direccion,
                    result.Telefono,
                    result.Contrasenia,
                    result.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("modificar")]
        public async Task<IActionResult> Update(ClienteRequest request)
        {
            try
            {
                ClienteResult result = await _clienteService.Update(request.Id,
                    request.Nombre,
                    request.Genero,
                    request.Edad,
                    request.Identificacion,
                    request.Direccion,
                    request.Telefono,
                    request.Contrasenia,
                    request.Estado);

                ClienteResponse response = new ClienteResponse(result.Id,
                    result.Nombre,
                    result.Genero,
                    result.Edad,
                    result.Identificacion,
                    result.Direccion,
                    result.Telefono,
                    result.Contrasenia,
                    result.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("borrar")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                ClienteResult result = await _clienteService.Delete(id);

                ClienteResponse response = new ClienteResponse(result.Id,
                    result.Nombre,
                    result.Genero,
                    result.Edad,
                    result.Identificacion,
                    result.Direccion,
                    result.Telefono,
                    result.Contrasenia,
                    result.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
