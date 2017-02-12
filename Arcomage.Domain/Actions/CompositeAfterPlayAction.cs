using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Коллекция действий, выполняемых после совершения хода игроком
    /// </summary>
    public class CompositeAfterPlayAction : IAfterPlayAction
    {
        /// <summary>
        /// Коллекция действий
        /// </summary>
        private readonly ICollection<IAfterPlayAction> playActionCollection;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="CompositeAfterPlayAction"/>
        /// </summary>
        /// <param name="playActionCollection">Коллекция действий</param>
        public CompositeAfterPlayAction(ICollection<IAfterPlayAction> playActionCollection)
        {
            this.playActionCollection = playActionCollection;
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="CompositeAfterPlayAction"/>
        /// </summary>
        /// <param name="playActionCollection">Коллекция действий</param>
        public CompositeAfterPlayAction(params IAfterPlayAction[] playActionCollection)
            : this(playActionCollection as ICollection<IAfterPlayAction>)
        {
            
        }

        /// <inheritdoc/>
        public void Play(Game game, PlayResult playResult)
        {
            foreach (var cardAction in playActionCollection)
                cardAction.Play(game, playResult);
        }
    }
}
