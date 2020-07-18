using Infrastructure.Common.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Common.UnitOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// List of actions done if commit is successful
        /// </summary>
        private readonly List<Action> _postCommitActions = new List<Action>();

        /// <summary>
        /// Commits the changes inside this instance of UOW
        /// </summary>
        /// <returns></returns>
        public async Task Commit()
        {
            await CommitCore();
            foreach (var action in _postCommitActions)
            {
                action();
            }
            _postCommitActions.Clear();
        }

        public void RegisterAction(Action action)
        {
            _postCommitActions.Add(action);
        }

        public void RegisterMultipleActions(IEnumerable<Action> actions)
        {
            _postCommitActions.AddRange(actions);
        }

        /// <summary>
        /// Performs the real commit work.
        /// </summary>
        protected abstract Task CommitCore();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();
    }
}