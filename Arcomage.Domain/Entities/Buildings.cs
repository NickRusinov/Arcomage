using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Arcomage.Domain.Entities
{
    public class Buildings
    {
        private int wall;

        private int tower;

        public Buildings(int wall, int tower)
        {
            this.wall = wall;
            this.tower = tower;
        }

        public int Wall
        {
            get { return wall; }
            set { wall = Max(value, 0); }
        }

        public int Tower
        {
            get { return tower; }
            set { tower = Max(value, 0); }
        }
    }
}
