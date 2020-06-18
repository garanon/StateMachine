namespace StateMachine.Scripts
{
    public abstract class StateTransitionRuleBase
    {
        #region Abstract Methods
        
        public abstract bool Evaluate();

        #endregion
    }
}
