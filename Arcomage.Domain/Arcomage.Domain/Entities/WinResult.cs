﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public class WinResult
    {
        public WinMode WinMode { get; set; }

        public PlayerMode WinPlayerMode { get; set; }
    }
}
