using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechPeanut.Api.Business;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Hypermedia.Filters;


namespace TechPeanut.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PessoasController : ControllerBase
    {
        private readonly ILogger<PessoasController> _logger;
        private IPessoaBusiness _pessoaBusiness;

        public PessoasController(ILogger<PessoasController> logger,
                                 IPessoaBusiness pessoaBusiness)
        {
            _logger = logger;
            _pessoaBusiness = pessoaBusiness;
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("")]
        [ProducesResponseType((200), Type = typeof(List<PessoasVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<PessoasVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            return Ok(_pessoaBusiness.FindById(id));
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PessoasVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PessoasVO pessoas)
        {
            if (pessoas == null) return BadRequest();

            return Ok(_pessoaBusiness.Create(pessoas));
        }

        // Mpas PUT requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PessoasVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PessoasVO pessoas)
        {
            if (pessoas == null) return BadRequest();

            return Ok(_pessoaBusiness.Update(pessoas));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _pessoaBusiness.Delete(id);
            return NoContent();
        }
    }
}
