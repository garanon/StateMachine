using System;

namespace StateMachine.Scripts
{
    public interface IStateMachineComponent
    {
        string Name { get; }
        IStateMachineComponent Evaluate();
        void AddTransition(IStateMachineComponent toComponent, Func<bool> predicate);
        void OnEnter();
    }
}
