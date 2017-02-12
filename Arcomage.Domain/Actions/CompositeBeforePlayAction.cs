using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Коллекция действий, выполняемых до получения хода игроком
    /// </summary>
    public class CompositeBeforePlayAction : IBeforePlayAction
    {
        /// <summary>
        /// Коллекция действий
        /// </summary>
        private readonly ICollection<IBeforePlayAction> playActionCollection;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="CompositeBeforePlayAction"/>
        /// </summary>
        /// <param name="playActionCollection">Коллекция действий</param>
        public CompositeBeforePlayAction(ICollection<IBeforePlayAction> playActionCollection)
        {
            this.playActionCollection = playActionCollection;
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="CompositeBeforePlayAction"/>
        /// </summary>
        /// <param name="playActionCollection">Коллекция действий</param>
        public CompositeBeforePlayAction(params IBeforePlayAction[] playActionCollection)
            : this(playActionCollection as ICollection<IBeforePlayAction>)
        {
            
        }

        /// <inheritdoc/>
        public void Play(Game game)
        {
            foreach (var playAction in playActionCollection)
                playAction.Play(game);
        }
    }
}
