using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Arcomage.Network;
using Arcomage.Network.Repositories;
using Arcomage.WebApi.Models.Game;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class GetGameApiController : ApplicationApiController
    {
        private readonly IGameRepository gameRepository;

        private readonly IGameContextRepository gameContextRepository;

        public GetGameApiController(IGameRepository gameRepository, IGameContextRepository gameContextRepository)
        {
            this.gameRepository = gameRepository;
            this.gameContextRepository = gameContextRepository;
        }

        [HttpGet, Route("~/api/game/{id:guid}")]
        public async Task<GameModel> GetGame(Guid id)
        {
            var gameContext = await gameContextRepository.GetById(id) ??
                throw new HttpException();

            var game = await gameRepository.GetById(gameContext.Id) ??
                throw new HttpException();

            return Mapper.Map<GameModel>((gameContext, game));
        }
    }
}