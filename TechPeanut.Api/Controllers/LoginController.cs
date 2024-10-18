using Microsoft.AspNetCore.Mvc;
using TechPeanut.Api.Business;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Hypermedia.Filters;

namespace TechPeanut.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private ILoginBusiness _loginBusiness;

        public LoginController(ILogger<LoginController> logger,
                               ILoginBusiness loginBusiness)
        {
            _logger = logger;
            _loginBusiness = loginBusiness;
        }

        // RETORNA TODOS USUÁRIOS
        [HttpGet("valida-login")]
        [ProducesResponseType((200), Type = typeof(List<LoginVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult ValidaAcesso(string E_Mail, string Senha)
        {
            return Ok(_loginBusiness.ValidaAcesso(E_Mail, Senha));
        }
    }
}
