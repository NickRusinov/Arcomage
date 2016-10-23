using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyChanged
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class ImplementPropertyChangedAttribute : Attribute
    {
    }
}