using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMS.Application.Services.Movimiento;
using PruebaMS.Contracts.Movimiento;

namespace PruebaMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _MovimientoService;

        public MovimientoController(IMovimientoService MovimientoService)
        {
            _MovimientoService = MovimientoService;
        }

        [HttpGet]
        public async Task<IActionResult> Movimientos()
        {
            try
            {
                var res = await _MovimientoService.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Movimiento(int id)
        {
            try
            {
                var res = await _MovimientoService.GetById(id);

                var response = new MovimientoResponse(
                    res.Id,
                    res.CuentaId,
                    res.Fecha,
                    res.Tipo,
                    res.Valor,
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
        public async Task<IActionResult> Create(MovimientoRequest request)
        {
            try
            {
                MovimientoResult res = await _MovimientoService.Create(request.CuentaId, request.Fecha,
                    request.Tipo, request.Valor); //, request.Saldo, request.Estado);

                MovimientoResponse response = new MovimientoResponse(res.Id, res.CuentaId, res.Fecha,
                    res.Tipo, res.Valor, res.Saldo, res.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Update(MovimientoRequest request)
        {
            try
            {
                MovimientoResult res = await _MovimientoService.Update(request.Id, request.CuentaId, request.Fecha,
                    request.Tipo, request.Valor, request.Saldo, request.Estado);

                MovimientoResponse response = new MovimientoResponse(res.Id, res.CuentaId, res.Fecha,
                    res.Tipo, res.Valor, res.Saldo, res.Estado);

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
                MovimientoResult res = await _MovimientoService.Delete(id);

                MovimientoResponse response = new MovimientoResponse(res.Id, res.CuentaId, res.Fecha,
                    res.Tipo, res.Valor, res.Saldo, res.Estado);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{inicio}, {fin}")]
        public async Task<IActionResult> ReporteFechas(DateTime inicio, DateTime fin)
        {
            try
            {
                var res = await _MovimientoService.ReporteFechas(inicio, fin);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
