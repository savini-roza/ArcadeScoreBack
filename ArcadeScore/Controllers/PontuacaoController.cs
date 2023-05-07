using ArcadeScore.Model;
using ArcadeScore.Services;
using ArcadeScore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArcadeScore.Controllers
{
    [ApiController]
    public class PontuacaoController : Controller
    {
        private readonly IPontuacaoService _pontuacaoService;
        public PontuacaoController(IPontuacaoService pontuacaoService)
        {
            _pontuacaoService = pontuacaoService;
        }

        [HttpGet]
        [Route("api/obter-ranking")]
        public ActionResult<IList<Pontuacao>> ObterRanking()
        {
            var ranking = _pontuacaoService.ObterRanking();
            return Ok(ranking);
        }

        [HttpPost]
        [Route("api/adicionar")]
        public ActionResult AdicionarPontuacao(Pontuacao pontuacao)
        {
            _pontuacaoService.Adicionar(pontuacao);
            return Ok();
        }
    }
}
