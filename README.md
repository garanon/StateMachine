#State Machine#

This is a solution for a nested state machine.

The goal of this set of scripts is to provide the ability to derive from the StateMachine class to implement a custom working state machine.

The need for this implementation came from some limitations of the state machine available in Unity. Namely:
- A state machine is tied to an Animator and an action can only be to play an Animation
- The inability to nest state machines gjhgjhg

The desired features are as follows:
- The ability to implement a custom state machine by deriving from the classes supplied.
- The implementation of a derived state machine should be as simple as possible, ideally defining only the states, their relation to one another, and their actions.
- Each state should be able to perform a unique defined action on entering the state.
- The state machine should be able to support nested state machines (i.e. a component of a state machine can be another state machine).