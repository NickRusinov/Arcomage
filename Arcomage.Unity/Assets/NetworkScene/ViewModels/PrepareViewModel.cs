using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.NetworkScene.ViewModels
{
    public class PrepareViewModel
    {
        public Command<object> ConnectCommand { get; set; }

        public Command<object> DisconnectCommand { get; set; }
    }
}
