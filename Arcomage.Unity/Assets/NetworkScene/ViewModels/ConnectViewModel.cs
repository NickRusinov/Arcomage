using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Models.About;

namespace Arcomage.Unity.NetworkScene.ViewModels
{
    public class ConnectViewModel
    {
        public Command<object, VersionModel> GetVersionCommand { get; set; }
    }
}
