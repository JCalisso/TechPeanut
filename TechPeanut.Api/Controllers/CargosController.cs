using Microsoft.AspNetCore.Mvc;
using TechPeanut.Api.Business;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Hypermedia.Filters;

namespace TechPeanut.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CargosController : ControllerBase
    {
        private readonly ILogger<CargosController> _logger;
        private ICargosBusiness _CargosBusiness;

        public CargosController(ILogger<CargosController> logger,
                                   ICargosBusiness CargosBusiness)
        {
            _logger = logger;
            _CargosBusiness = CargosBusiness;
        }

        [HttpGet("")]
        [ProducesResponseType((200), Type = typeof(List<CargosVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_CargosBusiness.FindAll());
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<CargosVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            return Ok(_CargosBusiness.FindById(id));
        }

        // Mpas POST requests to http://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(CargosVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] CargosVO Cargos)
        {
            if (Cargos == null) return BadRequest();

            return Ok(_CargosBusiness.Create(Cargos));
        }

        // Mpas PUT requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(CargosVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] CargosVO Cargos)
        {
            if (Cargos == null) return BadRequest();

            return Ok(_CargosBusiness.Update(Cargos));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _CargosBusiness.Delete(id);
            return NoContent();
        }
    }
}
