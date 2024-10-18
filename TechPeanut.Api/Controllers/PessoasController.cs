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
            return Ok(_pessoaBusiness.FindAll());
        }
    }
}
