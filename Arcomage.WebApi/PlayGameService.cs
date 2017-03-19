using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Arcomage.WebApi
{
    public class PlayGameService
    {
        public Task<PlayGameContext> ResolveGameContext(Guid userId)
        {
            var gameId = new Guid("0f9828da-022d-4e70-8c8a-f9959ad17c2d");
            var firstUserId = new Guid("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2");
            var secondUserId = new Guid("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3");

            return Task.FromResult(new PlayGameContext(gameId, firstUserId, secondUserId));
        }

        public Task<bool> PlayCard(Guid gameId, Guid userId, int cardIndex)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DiscardCard(Guid gameId, Guid userId, int cardIndex)
        {
            return Task.FromResult(true);
        }
    }

    public class PlayGameContext
    {
        public PlayGameContext(Guid gameId, Guid? firstUserId, Guid? secondUserId)
        {
            GameId = gameId;

            if (firstUserId is Guid firstId)
                FirstUser = new PlayUserContext(firstId);

            if (secondUserId is Guid secondId)
                SecondUser = new PlayUserContext(secondId);
        }

        public Guid GameId { get; }

        public PlayUserContext FirstUser { get; }

        public PlayUserContext SecondUser { get; }
    }

    public class PlayUserContext
    {
        public PlayUserContext(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}