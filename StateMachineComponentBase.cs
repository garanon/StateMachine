using System;
using System.Collections.Generic;

namespace StateMachine.Scripts
{
    public abstract class StateMachineComponentBase : IStateMachineComponent
    {
        #region Private Fields

        private IDictionary<IStateMachineComponent, Func<bool>> transitionList = new Dictionary<IStateMachineComponent, Func<bool>>();

        #endregion

        #region IStateMachineComponent Implementation

        public string Name { get; set; }

        public virtual IStateMachineComponent Evaluate()
        {
            foreach (var pair in transitionList)
            {
                if (pair.Value())
                {
                    return pair.Key;
                }
            }

            return this;
        }

        public abstract void OnEnter();

        #endregion

        #region Public Methods

        public void AddTransition(IStateMachineComponent toComponent, Func<bool> predicate)
        {
            transitionList[toComponent] = predicate;
        }

        #endregion
    }
}
