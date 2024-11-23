using Microsoft.AspNetCore.Mvc;
using TechPeanut.Api.Business;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Hypermedia.Filters;

namespace TechPeanut.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class FuncaoController : ControllerBase
    {
        private readonly ILogger<FuncaoController> _logger;
        private IFuncaoBusiness _FuncaoBusiness;

        public FuncaoController(ILogger<FuncaoController> logger,
                                   IFuncaoBusiness FuncaoBusiness)
        {
            _logger = logger;
            _FuncaoBusiness = FuncaoBusiness;
        }

        [HttpGet("")]
        [ProducesResponseType((200), Type = typeof(List<FuncaoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_FuncaoBusiness.FindAll());
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<FuncaoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            return Ok(_FuncaoBusiness.FindById(id));
        }

        // Mpas POST requests to http://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(FuncaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] FuncaoVO funcao)
        {
            if (funcao == null) return BadRequest();

            return Ok(_FuncaoBusiness.Create(funcao));
        }

        // Mpas PUT requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object set in the request body
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(FuncaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] FuncaoVO funcao)
        {
            if (funcao == null) return BadRequest();

            return Ok(_FuncaoBusiness.Update(funcao));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _FuncaoBusiness.Delete(id);
            return NoContent();
        }
    }
}
