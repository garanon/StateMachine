using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.Scripts
{
    public abstract class StateMachine<T> : StateMachineComponentBase where T : IStateMachineManager
    {
        #region Properties

        public abstract string EntryStateName { get; }
        protected T Owner { get; private set; }

        #endregion

        #region Private Fields

        private IList<IStateMachineComponent> stateList;
        private IStateMachineComponent currentState;

        #endregion

        #region Abstract Methods

        public abstract void InitialiseStates();
        public abstract void InitialiseBranches();

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return $"{Name} => {currentState}";
        }

        #endregion

        #region StateMachineComponentBase Implementation

        public override IStateMachineComponent Evaluate()
        {
            var nextState = base.Evaluate();
            if (nextState != this)
            {
                return nextState;
            }

            var newState = currentState.Evaluate();
            if (newState != currentState)
            {
                currentState = newState;
                currentState.OnEnter();
            }

            return this;
        }

        public override void OnEnter()
        {
            // Initialise the default state.
            currentState = GetState(EntryStateName);
            currentState.OnEnter();
        }

        #endregion

        #region Public Methods

        public virtual void Initialise(T owner)
        {
            Owner = owner;
            stateList = new List<IStateMachineComponent>();

            InitialiseStates();
            InitialiseBranches();

            currentState = GetState(EntryStateName);
        }

        public void AddComponent(IStateMachineComponent component)
        {
            stateList.Add(component);
        }

        public void AddBranch(string from, string to, Func<bool> predicate)
        {
            var fromState = GetState(from);
            var toState = GetState(to);
            fromState.AddTransition(toState, predicate);
        }

        public IStateMachineComponent GetState(string name)
        {
            return stateList.FirstOrDefault(state => state.Name == name);
        }

        #endregion
    }
}
