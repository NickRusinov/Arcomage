using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.Unity.NetworkScene.ViewModels;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class PreparePanelView : View<PrepareViewModel>
    {
        public void OnEnable()
        {
            Bind(ViewModel.ConnectCommand.Execute(ViewModel));
        }

        public void OnDisable()
        {
            Bind(ViewModel.DisconnectCommand.Execute(ViewModel));
        }
    }
}
