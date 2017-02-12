using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using static System.Math;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Класс, описывающий значения одного из игровых ресурсов игрока
    /// </summary>
    [Serializable]
    public class Resource
    {
        /// <summary>
        /// Значение прироста ресурса
        /// </summary>
        private int increase;

        /// <summary>
        /// Количество ресурсов
        /// </summary>
        private int value;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="Resource"/>
        /// </summary>
        /// <param name="increase">Значение прироста ресурса</param>
        /// <param name="value">Количество ресурсов</param>
        public Resource(int increase, int value)
        {
            Contract.Requires(increase >= 0);
            Contract.Requires(value >= 0);

            this.increase = increase;
            this.value = value;
        }

        /// <summary>
        /// Значение прироста ресурса
        /// </summary>
        public int Increase
        {
            get { return increase; }
            set { increase = Max(value, 0); }
        }

        /// <summary>
        /// Количество ресурсов
        /// </summary>
        public int Value
        {
            get { return value; }
            set { this.value = Max(value, 0); }
        }
    }
}
