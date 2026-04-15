using Microsoft.AspNetCore.Mvc;
using ApiCafeteria.Models;
using ApiCafeteria.Services;

namespace ApiCafeteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        private readonly BebidaService _bebidaService;

        public BebidasController(BebidaService bebidaService)
        {
            _bebidaService = bebidaService;
        }

        [HttpGet]
        public ActionResult<List<Bebida>> Get()
        {
            var bebidas = _bebidaService.ObtenerBebidas();
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public ActionResult<Bebida> GetById(int id)
        {
            var bebida = _bebidaService.ObtenerBebidaPorId(id);

            if (bebida == null)
            {
                return NotFound(new { mensaje = "Bebida no encontrada" });
            }

            return Ok(bebida);
        }
    }
}