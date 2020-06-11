using System;
using System.Collections.Generic;

namespace StateMachine.Scripts
{
    public abstract class StateMachineComponentBase
    {
        #region Properties

        public virtual string Name { get; set; }

        #endregion

        #region Private Fields

        private IDictionary<StateMachineComponentBase, Func<bool>> transitionList;

        #endregion

        #region Abstract Methods

        public abstract void OnEnter();

        #endregion

        #region Public Methods

        public virtual StateMachineComponentBase Evaluate()
        {
            if (transitionList != null && transitionList.Count > 0)
            {
                foreach (var pair in transitionList)
                {
                    if (pair.Value())
                    {
                        return pair.Key;
                    }
                }
            }

            return this;
        }

        public virtual void AddTransition(StateMachineComponentBase toComponent, Func<bool> predicate)
        {
            if (transitionList == null)
            {
                transitionList = new Dictionary<StateMachineComponentBase, Func<bool>>();
            }

            transitionList[toComponent] = predicate;
        }

        #endregion
    }
}
