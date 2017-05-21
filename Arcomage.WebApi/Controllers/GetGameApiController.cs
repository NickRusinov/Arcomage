using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Arcomage.Network;
using Arcomage.WebApi.Models.Game;
using AutoMapper;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class GetGameApiController : ApplicationApiController
    {
        private readonly IRepository<GameContext> gameContextRepository;

        public GetGameApiController(IRepository<GameContext> gameContextRepository)
        {
            this.gameContextRepository = gameContextRepository;
        }

        [HttpGet, Route("~/api/game/{id:guid}")]
        public async Task<GameModel> GetGame(Guid id)
        {
            var gameContext = await gameContextRepository.GetById(id) ??
                throw new HttpException();

            return Mapper.Map<GameModel>((gameContext, Identity.User, gameContext.Game));
        }
    }
}