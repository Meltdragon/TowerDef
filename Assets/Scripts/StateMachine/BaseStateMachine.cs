using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine
{
    protected BaseState currentState = null;
    protected List<BaseState> states;
    protected List<Transition> transitions;

    public BaseStateMachine()
    {
        states = new List<BaseState>();
        transitions = new List<Transition>();
    }

    public virtual void ChangeState(BaseState newState)
    {
        if(currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;
        currentState.OnEnter();
    }

    public virtual void ExecuteState()
    {
        currentState.OnExecute();
        CheckTransitions();
    }

    public virtual void CheckTransitions()
    {
        foreach(Transition transition in currentState.transitions)
        {
            if(transition.condition())
            {
                ChangeState(transition.targetState);
                break;
            }
        }
    }

    protected abstract void DefineTransition();
}
