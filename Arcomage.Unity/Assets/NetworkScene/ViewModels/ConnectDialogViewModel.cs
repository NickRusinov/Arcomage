using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.NetworkScene.ViewModels
{
    public class ConnectDialogViewModel
    {
        public Command<object> DisconnectGameCommand { get; set; }
    }
}
