using Microsoft.AspNetCore.Mvc;
using TechPeanut.Api.Business;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Hypermedia.Filters;

namespace TechPeanut.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class EnderecosController : ControllerBase
    {
        private readonly ILogger<EnderecosController> _logger;
        private IEnderecosBusiness _enderecosBusiness;

        public EnderecosController(ILogger<EnderecosController> logger,
                                   IEnderecosBusiness enderecosBusiness)
        {
            _logger = logger;
            _enderecosBusiness = enderecosBusiness;
        }

        [HttpGet("")]
        [ProducesResponseType((200), Type = typeof(List<EnderecosVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_enderecosBusiness.FindAll());
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<EnderecosVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            return Ok(_enderecosBusiness.FindById(id));
        }

        // Mpas POST requests to http://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(EnderecosVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] EnderecosVO enderecos)
        {
            if (enderecos == null) return BadRequest();

            return Ok(_enderecosBusiness.Create(enderecos));
        }

        // Mpas PUT requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(EnderecosVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] EnderecosVO enderecos)
        {
            if (enderecos == null) return BadRequest();

            return Ok(_enderecosBusiness.Update(enderecos));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _enderecosBusiness.Delete(id);
            return NoContent();
        }
    }
}
