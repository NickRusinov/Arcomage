using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Rules
{
    /// <summary>
    /// Описание классических правил игры
    /// </summary>
    [Serializable]
    public class ClassicRuleInfo : RuleInfo
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ClassicRuleInfo"/>
        /// </summary>
        /// <param name="identifier">Идентификатор правил игры</param>
        /// <param name="quarry">Количество шахт</param>
        /// <param name="bricks">Количество руды</param>
        /// <param name="magic">Количество монастырей</param>
        /// <param name="gems">Количество маны</param>
        /// <param name="dungeons">Количество казарм</param>
        /// <param name="recruits">Количество отрядов</param>
        /// <param name="wall">Высота стены</param>
        /// <param name="tower">Высота башни</param>
        /// <param name="maxTower">Необходимая высота башни для победы</param>
        /// <param name="maxResources">Необходимое количество ресурсов для победы</param>
        /// <param name="timeout">Количество ходов, пропуск которых приведет к поражению по таймауту</param>
        public ClassicRuleInfo(string identifier, int quarry, int bricks, int magic, int gems, int dungeons, 
            int recruits, int wall, int tower, int maxTower, int maxResources, int timeout)
            : base(identifier)
        {
            Quarry = quarry;
            Bricks = bricks;
            Magic = magic;
            Gems = gems;
            Dungeons = dungeons;
            Recruits = recruits;
            Wall = wall;
            Tower = tower;
            MaxTower = maxTower;
            MaxResources = maxResources;
            Timeout = timeout;
        }

        /// <summary>
        /// Количество шахт
        /// </summary>
        public int Quarry { get; }

        /// <summary>
        /// Количество руды
        /// </summary>
        public int Bricks { get; }

        /// <summary>
        /// Количество монастырей
        /// </summary>
        public int Magic { get; }

        /// <summary>
        /// Количество маны
        /// </summary>
        public int Gems { get; }

        /// <summary>
        /// Количество казарм
        /// </summary>
        public int Dungeons { get; }

        /// <summary>
        /// Количество отрядов
        /// </summary>
        public int Recruits { get; }

        /// <summary>
        /// Высота стены
        /// </summary>
        public int Wall { get; }

        /// <summary>
        /// Высота башни
        /// </summary>
        public int Tower { get; }

        /// <summary>
        /// Необходимая высота башни для победы
        /// </summary>
        public int MaxTower { get; }

        /// <summary>
        /// Необходимое количество ресурсов для победы
        /// </summary>
        public int MaxResources { get; }

        /// <summary>
        /// Количество ходов, пропуск которых приведет к поражению по таймауту
        /// </summary>
        public int Timeout { get; }
    }
}
