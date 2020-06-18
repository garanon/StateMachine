using System;
using System.Collections.Generic;

namespace StateMachine.Scripts
{
    public abstract class StateMachineComponentBase
    {
        #region Properties

        public virtual string Name { get; set; }
        public virtual int TransitionRuleCount => transitionList?.Count ?? 0;

        #endregion

        #region Private Fields

        private IDictionary<StateMachineComponentBase, StateTransitionRuleBase> transitionList;

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
                    if (pair.Value.Evaluate())
                    {
                        return pair.Key;
                    }
                }
            }

            return this;
        }

        public virtual void AddTransition(StateMachineComponentBase toComponent, StateTransitionRuleBase transitionRuleRule)
        {
            if (transitionList == null)
            {
                transitionList = new Dictionary<StateMachineComponentBase, StateTransitionRuleBase>();
            }

            transitionList[toComponent] = transitionRuleRule;
        }

        public virtual bool IsFinished()
        {
            return true;
        }

        #endregion
    }
}
