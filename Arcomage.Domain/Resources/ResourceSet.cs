using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Domain.Resources
{
    /// <summary>
    /// Класс, описывающий игровые ресурсы игрока
    /// </summary>
    [Serializable]
    public class ResourceSet
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ResourceSet"/> 
        /// </summary>
        /// <param name="quarry">Количество шахт</param>
        /// <param name="bricks">Количество руды</param>
        /// <param name="magic">Количество монастырей</param>
        /// <param name="gems">Количество маны</param>
        /// <param name="dungeons">Количество казарм</param>
        /// <param name="recruits">Количество отрядов</param>
        public ResourceSet(int quarry, int bricks, int magic, int gems, int dungeons, int recruits)
            : this(new Resource(quarry, bricks), new Resource(magic, gems), new Resource(dungeons, recruits))
        {
            Contract.Requires(quarry >= 0);
            Contract.Requires(bricks >= 0);
            Contract.Requires(magic >= 0);
            Contract.Requires(gems >= 0);
            Contract.Requires(dungeons >= 0);
            Contract.Requires(recruits >= 0);
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ResourceSet"/>
        /// </summary>
        /// <param name="bricksResource">Игровой ресурс "Руда"</param>
        /// <param name="gemsResource">Игровой ресурс "Мана"</param>
        /// <param name="recruitsResource">Игровой ресурс "Отряды"</param>
        public ResourceSet(Resource bricksResource, Resource gemsResource, Resource recruitsResource)
        {
            Contract.Requires(bricksResource != null);
            Contract.Requires(gemsResource != null);
            Contract.Requires(recruitsResource != null);

            BricksResource = bricksResource;
            GemsResource = gemsResource;
            RecruitsResource = recruitsResource;
        }

        /// <summary>
        /// Игровой ресурс "Руда"
        /// </summary>
        public Resource BricksResource { get; }

        /// <summary>
        /// Игровой ресурс "Мана"
        /// </summary>
        public Resource GemsResource { get; }

        /// <summary>
        /// Игровой ресурс "Отряды"
        /// </summary>
        public Resource RecruitsResource { get; }

        /// <summary>
        /// Количество шахт
        /// </summary>
        public int Quarry
        {
            get { return BricksResource.Increase; }
            set { BricksResource.Increase = value; }
        }

        /// <summary>
        /// Количество руды
        /// </summary>
        public int Bricks
        {
            get { return BricksResource.Value; }
            set { BricksResource.Value = value; }
        }

        /// <summary>
        /// Количество монастырей
        /// </summary>
        public int Magic
        {
            get { return GemsResource.Increase; }
            set { GemsResource.Increase = value; }
        }

        /// <summary>
        /// Количество маны
        /// </summary>
        public int Gems
        {
            get { return GemsResource.Value; }
            set { GemsResource.Value = value; }
        }

        /// <summary>
        /// Количество казарм
        /// </summary>
        public int Dungeons
        {
            get { return RecruitsResource.Increase; }
            set { RecruitsResource.Increase = value; }
        }

        /// <summary>
        /// Количество отрядов
        /// </summary>
        public int Recruits
        {
            get { return RecruitsResource.Value; }
            set { RecruitsResource.Value = value; }
        }

        /// <summary>
        /// Получение одного из ресурсов игрока по указанному типу ресурса
        /// </summary>
        /// <param name="kind">Тип ресурса</param>
        /// <returns>Один из ресурсов игрока</returns>
        public Resource this[ResourceKind kind]
        {
            get { return GetResource(kind); }
        }

        /// <summary>
        /// Получение одного из ресурсов игрока по указанному типу ресурса
        /// </summary>
        /// <param name="kind">Тип ресурса</param>
        /// <returns>Один из ресурсов игрока</returns>
        private Resource GetResource(ResourceKind kind)
        {
            Contract.Requires(Enum.IsDefined(typeof(ResourceKind), kind));
            Contract.Ensures(Contract.Result<Resource>() != null);

            switch (kind)
            {
                case ResourceKind.Bricks:
                    return BricksResource;

                case ResourceKind.Gems:
                    return GemsResource;

                case ResourceKind.Recruits:
                    return RecruitsResource;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
