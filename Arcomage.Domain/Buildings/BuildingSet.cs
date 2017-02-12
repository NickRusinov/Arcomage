using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using static System.Math;

namespace Arcomage.Domain.Buildings
{
    /// <summary>
    /// Класс, описывающий строения игрока
    /// </summary>
    [Serializable]
    public class BuildingSet
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="BuildingSet"/>
        /// </summary>
        /// <param name="wall">Высота стены</param>
        /// <param name="tower">Высота башни</param>
        public BuildingSet(int wall, int tower)
            : this(new Building(wall), new Building(tower))
        {
            Contract.Requires(wall >= 0);
            Contract.Requires(tower >= 0);
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="BuildingSet"/>
        /// </summary>
        /// <param name="wallBuilding">Строение "Стена"</param>
        /// <param name="towerBuilding">Строение "Башня"</param>
        public BuildingSet(Building wallBuilding, Building towerBuilding)
        {
            Contract.Requires(wallBuilding != null);
            Contract.Requires(towerBuilding != null);

            WallBuilding = wallBuilding;
            TowerBuilding = towerBuilding;
        }

        /// <summary>
        /// Строение "Стена"
        /// </summary>
        public Building WallBuilding { get; }

        /// <summary>
        /// Строение "Башня"
        /// </summary>
        public Building TowerBuilding { get; }

        /// <summary>
        /// Высота стены
        /// </summary>
        public int Wall
        {
            get { return WallBuilding.Height; }
            set { WallBuilding.Height = value; }
        }

        /// <summary>
        /// Высота башни
        /// </summary>
        public int Tower
        {
            get { return TowerBuilding.Height; }
            set { TowerBuilding.Height = value; }
        }

        /// <summary>
        /// Суммарная высота башни и стены
        /// </summary>
        public int Full
        {
            get { return Wall + Tower; }
            set { SetFull(Max(value, 0)); }
        }

        /// <summary>
        /// Получение одного из строений игрока по указанномц типу строения
        /// </summary>
        /// <param name="kind">Тип строения</param>
        /// <returns>Одно из строний игрока</returns>
        public Building this[BuildingKind kind]
        {
            get { return GetResource(kind); }
        }

        /// <summary>
        /// Получение одного из строений игрока по указанномц типу строения
        /// </summary>
        /// <param name="kind">Тип строения</param>
        /// <returns>Одно из строний игрока</returns>
        private Building GetResource(BuildingKind kind)
        {
            Contract.Requires(Enum.IsDefined(typeof(BuildingKind), kind));
            Contract.Ensures(Contract.Result<Building>() != null);

            switch (kind)
            {
                case BuildingKind.Wall:
                    return WallBuilding;

                case BuildingKind.Tower:
                    return TowerBuilding;

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Устанавливает суммарную высоту стены и башни, так что, при увеличении <paramref name="value"/> 
        /// увеличивается стена, а при уменьшении <paramref name="value"/> сначала уменьшается стена и, если стена 
        /// уменьшена до 0, уменьшается башня
        /// </summary>
        /// <param name="value">Устанавливаемое уммарное значение стены и башни</param>
        private void SetFull(int value)
        {
            Contract.Requires(value >= 0);

            Tower = Min(Tower, value);
            Wall = value - Tower;
        }
    }
}
