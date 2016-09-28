using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain
{
    public interface IIdentifiable
    {
        string Identifier { get; }
    }
}
