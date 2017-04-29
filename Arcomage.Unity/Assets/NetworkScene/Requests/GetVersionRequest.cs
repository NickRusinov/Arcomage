using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.WebApi.Client.Models.About;
using MediatR;

namespace Arcomage.Unity.NetworkScene.Requests
{
    public class GetVersionRequest : IRequest<VersionModel>
    {
    }
}
