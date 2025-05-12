using Microsoft.AspNetCore.Mvc;
using Odido.BusinessLogic.Interfaces;
using Odido.WebApi.DTO;
using Odido.WebApi.Extensions;

namespace Odido.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<GameResponse>> CreateGame(CreateGameRequest request)
        {
            var game = await _gameService.CreateNewGame(request.PlayerName);
            return Ok(game.ToResponse());
        }

        [HttpGet("player/{playerName}")]
        public async Task<ActionResult<IEnumerable<GameResponse>>> GetActiveGamesByPlayer(string playerName)
        {
            var games = await _gameService.GetGamesByPlayer(playerName);
            return Ok(games.Select(g=>g.ToResponse()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponse>> GetGame(int id)
        {
            var game = await _gameService.GetGameById(id);
            if (game is null)
            {
                return NotFound();
            }

            return Ok(game.ToResponse());
        }

        [HttpPost("{id}/play")]
        public async Task<ActionResult<GameActionResultResponse>> PlayTurn(int id, PlayTurnRequest request)
        {
            try
            {
                var result = await _gameService.PlayTurn(id, request.Action);
                return Ok(new GameActionResultResponse
                {
                    Game = result.ToResponse(),
                    ActionMessage = result.GetLastLogEntry()
                });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
