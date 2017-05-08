using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Repositories;
using Arcomage.Network.Requests;
using Hangfire;
using MediatR;

namespace Arcomage.Network.Jobs
{
    public class CreateGameJob
    {
        private readonly IMediator mediator;

        private readonly IGameContextRepository gameContextRepository;

        public CreateGameJob(IMediator mediator, IGameContextRepository gameContextRepository)
        {
            this.mediator = mediator;
            this.gameContextRepository = gameContextRepository;
        }

        public async Task Start()
        {
            while (true)
            {
                var userContextEnumerable = await mediator.Send(new GetConnectingUsersRequest());
                var userContextList = userContextEnumerable.ToList();

                for (var i = 0; i < userContextList.Count / 2; ++i)
                {
                    var createGameRequest = new CreateGameRequest(userContextList[i], userContextList[i + 1]);
                    var gameContext = await mediator.Send(createGameRequest);

                    var jobId = BackgroundJob.Enqueue<PlayGameJob>(j => j.Start(gameContext));
                    await gameContextRepository.Update(gameContext, gc => gc.JobId = jobId);
                }

                if (userContextList.Count % 2 == 1)
                {
                    var computerUserContext = UserContext.New("Computer Player", UserKind.Computer);
                    var createGameRequest = new CreateGameRequest(userContextList[userContextList.Count - 1], computerUserContext);
                    var gameContext = await mediator.Send(createGameRequest);

                    var jobId = BackgroundJob.Enqueue<PlayGameJob>(j => j.Start(gameContext));
                    await gameContextRepository.Update(gameContext, gc => gc.JobId = jobId);
                }

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }
    }
}
