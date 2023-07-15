using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; } //принимаем состояние
    public void Initialize(State startState) // вызываем стартовое состояние 
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(State newState) // меняем состояние
    {
        if(CurrentState != newState) // проверка на то чтоб мы не обновили текущее состояниее им же
        {

        CurrentState.Exit(); // выходим из старого состояния

        CurrentState = newState;
        CurrentState.Enter(); // входим в новое состояние
        }
    }
}
