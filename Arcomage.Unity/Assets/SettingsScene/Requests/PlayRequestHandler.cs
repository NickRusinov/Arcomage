using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Unity.Shared.Scripts;
using MediatR;

namespace Arcomage.Unity.SettingsScene.Requests
{
    public class PlayRequestHandler : IRequestHandler<PlayRequest>
    {
        private readonly SingleSettings singleSettings;

        private readonly GameBuilder gameBuilder;

        public PlayRequestHandler(SingleSettings singleSettings, GameBuilder gameBuilder)
        {
            this.singleSettings = singleSettings;
            this.gameBuilder = gameBuilder;
        }

        public void Handle(PlayRequest message)
        {
            singleSettings.GameBuilderContext = gameBuilder.CreateContext();
        }
    }
}
