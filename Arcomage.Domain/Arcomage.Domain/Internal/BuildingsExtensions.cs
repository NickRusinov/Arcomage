using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using static System.Math;

namespace Arcomage.Domain.Internal
{
    internal static class BuildingsExtensions
    {
        public static void Damage(this Buildings buildings, int damage)
        {
            var wallDamage = Min(buildings.Wall, damage);
            var towerDamage = Min(buildings.Tower, damage - wallDamage);

            buildings.Wall -= wallDamage;
            buildings.Tower -= towerDamage;
        }
    }
}
