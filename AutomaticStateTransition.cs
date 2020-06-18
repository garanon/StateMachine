namespace StateMachine.Scripts
{
    public class AutomaticStateTransition : StateTransitionRuleBase
    {
        #region Fields

        private readonly StateMachineComponentBase component;

        #endregion

        #region ctor

        public AutomaticStateTransition(StateMachineComponentBase component)
        {
            this.component = component;
        }

        #endregion

        #region StateTransitionRuleBase Implementation

        public override bool Evaluate()
        {
            return component.IsFinished() && component.TransitionRuleCount == 0;
        }

        #endregion
    }
}
