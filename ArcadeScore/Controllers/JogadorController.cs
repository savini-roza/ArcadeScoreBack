using ArcadeScore.Model;
using ArcadeScore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArcadeScore.Controllers
{
    [ApiController]
    public class JogadorController : Controller
    {
        private readonly IJogadorService _jogadorService;
        public JogadorController(IJogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }

        [HttpGet]
        [Route("api/obter-jogador")]
        public ActionResult<Jogador> ObterJogador(string nome)
        {
            var jogador = _jogadorService.ObterJogador(nome);
            return Ok(jogador);
        }
    }
}
