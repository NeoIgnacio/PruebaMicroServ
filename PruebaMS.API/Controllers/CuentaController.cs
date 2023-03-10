using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMS.Application.Services.Cuenta;
using PruebaMS.Contracts.Cuenta;

namespace PruebaMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> Cuentas()
        {
            try
            {
                var res = await _cuentaService.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Cuenta(int id)
        {
            try
            {
                var res = await _cuentaService.GetById(id);

                var response = new CuentaResponse(
                    res.Id,
                    res.ClienteId,
                    res.Numero,
                    res.Tipo,
                    res.Saldo,
                    res.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Create(CuentaRequest request)
        {
            try
            {
                CuentaResult res = await _cuentaService.Create(request.ClienteId, request.Numero,
                    request.Tipo, request.Saldo, request.Estado);

                CuentaResponse response = new CuentaResponse(res.Id, res.ClienteId, res.Numero,
                    res.Tipo, res.Saldo, res.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Update(CuentaRequest request)
        {
            try
            {
                CuentaResult res = await _cuentaService.Update(request.Id, request.ClienteId, request.Numero,
                    request.Tipo, request.Saldo, request.Estado);

                CuentaResponse response = new CuentaResponse(res.Id, res.ClienteId, res.Numero,
                    res.Tipo, res.Saldo, res.Estado);

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
                CuentaResult res = await _cuentaService.Delete(id);

                CuentaResponse response = new CuentaResponse(res.Id, res.ClienteId, res.Numero,
                    res.Tipo, res.Saldo, res.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
