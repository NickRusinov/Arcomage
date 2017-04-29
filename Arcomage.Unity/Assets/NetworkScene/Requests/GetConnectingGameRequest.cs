using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;

namespace Arcomage.Unity.NetworkScene.Requests
{
    public class GetConnectingGameRequest : IRequest<Guid?>
    {
    }
}
