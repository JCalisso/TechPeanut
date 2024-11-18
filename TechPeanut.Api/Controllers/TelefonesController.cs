using Microsoft.AspNetCore.Mvc;
using TechPeanut.Api.Business;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Hypermedia.Filters;

namespace TechPeanut.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TelefonesController : ControllerBase
    {
        private readonly ILogger<TelefonesController> _logger;
        private ITelefoneBusiness _telefoneBusiness;

        public TelefonesController(ILogger<TelefonesController> logger,
                                   ITelefoneBusiness telefoneBusiness)
        {
            _logger = logger;
            _telefoneBusiness = telefoneBusiness;
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("")]
        [ProducesResponseType((200), Type = typeof(List<TelefonesVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_telefoneBusiness.FindAll());
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<TelefonesVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            return Ok(_telefoneBusiness.FindById(id));
        }

        // Mpas POST requests to http://localhost:{port}/api/telefone/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(TelefonesVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] TelefonesVO telefone)
        {
            if (telefone == null) return BadRequest();

            return Ok(_telefoneBusiness.Create(telefone));
        }

        // Mpas PUT requests to https://localhost:{port}/api/telefone/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(TelefonesVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] TelefonesVO telefone)
        {
            if (telefone == null) return BadRequest();

            return Ok(_telefoneBusiness.Update(telefone));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _telefoneBusiness.Delete(id);
            return NoContent();
        }
    }
}
