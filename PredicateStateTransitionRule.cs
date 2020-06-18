using System;

namespace StateMachine.Scripts
{
    public class PredicateStateTransitionRule : StateTransitionRuleBase
    {
        #region Fields

        private readonly Func<bool> predicate;

        #endregion

        #region ctor

        public PredicateStateTransitionRule(Func<bool> predicate)
        {
            this.predicate = predicate;
        }

        #endregion

        #region StateTransitionRuleBase Implementation

        public override bool Evaluate()
        {
            return predicate();
        }

        #endregion
    }
}
