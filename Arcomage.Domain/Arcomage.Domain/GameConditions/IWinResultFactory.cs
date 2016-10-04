using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.GameConditions
{
    public interface IWinResultFactory
    {
        WinResult CreateBuildTowerWinResult(PlayerMode winPlayerMode);

        WinResult CreateDestroyTowerWinResult(PlayerMode winPlayerMode);

        WinResult CreateAccumulateResourcesWinResult(PlayerMode winPlayerMode);
    }
}
