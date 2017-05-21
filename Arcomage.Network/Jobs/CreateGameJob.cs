using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using Hangfire;
using MediatR;

namespace Arcomage.Network.Jobs
{
    public class CreateGameJob
    {
        private readonly IMediator mediator;

        private readonly IRepository<GameContext> gameContextRepository;

        public CreateGameJob(IMediator mediator, IRepository<GameContext> gameContextRepository)
        {
            this.mediator = mediator;
            this.gameContextRepository = gameContextRepository;
        }

        public async Task Start()
        {
            while (true)
            {
                var getConnectingUsersRequest = new GetConnectingUsersRequest();
                var userList = (await mediator.Send(getConnectingUsersRequest)).ToList();

                for (var i = 0; i < userList.Count / 2; ++i)
                {
                    var createGameRequest = new CreateGameRequest(userList[i], userList[i + 1]);
                    var gameContext = await mediator.Send(createGameRequest);

                    var jobId = BackgroundJob.Enqueue<PlayGameJob>(j => j.Start(gameContext.Id));
                    await gameContextRepository.Update(gameContext, gc => gc.JobId = jobId);
                }

                if (userList.Count % 2 == 1)
                {
                    var createGameRequest = new CreateGameRequest(userList[userList.Count - 1], User.ComputerUser);
                    var gameContext = await mediator.Send(createGameRequest);

                    var jobId = BackgroundJob.Enqueue<PlayGameJob>(j => j.Start(gameContext.Id));
                    await gameContextRepository.Update(gameContext, gc => gc.JobId = jobId);
                }

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }
    }
}
