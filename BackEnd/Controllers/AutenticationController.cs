using BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController, Route("v1/[controller]")]
    public class AutenticationController
    {
        [HttpGet, Route(""), AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate() =>
            new
            {
                Token = TokenService.GenerateToken()
            };
    }
}
