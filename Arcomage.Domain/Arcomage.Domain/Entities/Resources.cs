using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Arcomage.Domain.Entities
{
    public class Resources
    {
        private int quarry;

        private int bricks;

        private int magic;

        private int gems;

        private int dungeons;

        private int recruits;

        public int Quarry
        {
            get { return quarry; }
            set { quarry = Max(value, 0); }
        }

        public int Bricks
        {
            get { return bricks; }
            set { bricks = Max(value, 0); }
        }

        public int Magic
        {
            get { return magic; }
            set { magic = Max(value, 0); }
        }

        public int Gems
        {
            get { return gems; }
            set { gems = Max(value, 0); }
        }

        public int Dungeons
        {
            get { return dungeons; }
            set { dungeons = Max(value, 0); }
        }

        public int Recruits
        {
            get { return recruits; }
            set { recruits = Max(value, 0); }
        }
    }
}
