using System;

namespace StateMachine.Scripts
{
    public class State : StateMachineComponentBase
    {
        #region Private Fields

        private readonly Action onStateEnterAction;

        #endregion

        #region ctor

        public State(string stateName, Action onEnterAction)
        {
            Name = stateName;
            onStateEnterAction = onEnterAction;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region State Implementation

        public override void OnEnter()
        {
            onStateEnterAction?.Invoke();
        }

        #endregion
    }
}
