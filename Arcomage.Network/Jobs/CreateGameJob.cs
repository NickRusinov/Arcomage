using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Queries;
using Arcomage.Network.Services;

namespace Arcomage.Network.Jobs
{
    public class CreateGameJob
    {
        private readonly ICreateGameService createGameService;

        private readonly IGetConnectingUsersQuery getConnectingUsersQuery;

        public CreateGameJob(ICreateGameService createGameService, IGetConnectingUsersQuery getConnectingUsersQuery)
        {
            this.createGameService = createGameService;
            this.getConnectingUsersQuery = getConnectingUsersQuery;
        }

        public async Task Start()
        {
            while (true)
            {
                var userContextEnumerable = await getConnectingUsersQuery.Handle();
                var userContextList = userContextEnumerable.ToList();

                for (var i = 0; i < userContextList.Count / 2; ++i)
                {
                    await createGameService.CreateGame(userContextList[i], userContextList[i + 1]);
                }

                if (userContextList.Count % 2 == 1)
                {
                    await createGameService.CreateGame(userContextList[userContextList.Count - 1], UserContext.New());
                }

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }
    }
}
